using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;

namespace AdvancedRenamer.TheTVDB
{
    [Flags]
    public enum MirrorType
    {
        XmlFiles = 1,
        BannerFiles = 2,
        ZipFiles = 4
    }

    public class TvDBApi
    {
        #region Member Variables

        private string _url = String.Empty;
        private string _apiKey = String.Empty;
        private string _lang = "en";
        private static TvDBApi _instance = null;

        private List<TvDBMirror> _mirrors = new List<TvDBMirror>();

        #endregion

        #region Properties

        /// <summary>
        /// The instance of the initalised API object
        /// </summary>
        public static TvDBApi Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        /// <summary>
        /// The URL to access the API on
        /// </summary>
        public string ApiUrl
        {
            get { return _url; }
            private set { _url = value; }
        }

        /// <summary>
        /// The API key to use when accessing the TV db API.
        /// </summary>
        public string ApiKey
        {
            get { return _apiKey; }
            private set { _apiKey = value; }
        }

        /// <summary>
        /// The language to access the API in
        /// </summary>
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }

        #endregion


        public static TvDBApi Create(string url, string apiKey)
        {
            if (Instance == null)
                Instance = new TvDBApi(url, apiKey);

            return Instance;
        }

        /// <summary>
        /// Private constructor for creating the API object
        /// </summary>
        /// <param name="url">The URL to access th API on</param>
        /// <param name="apiKey">The API key to use when accessing the API</param>
        private TvDBApi(string url, string apiKey)
        {
            ApiKey = apiKey;
            ApiUrl = url;

            DownloadMirrors();
        }

        /// <summary>
        /// Gets the API mirror sites. This is an async download
        /// </summary>
        private void DownloadMirrors()
        {
            string url = ApiUrl + "/api/" + ApiKey + "/mirrors.xml";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Timeout = 5000;
            req.BeginGetResponse(new AsyncCallback(DownloadMirrorsCallback), req);
        }


        /// <summary>
        /// Async callback for the mirrors.xml download
        /// </summary>
        private void DownloadMirrorsCallback(IAsyncResult result)
        {
            HttpWebRequest req = (HttpWebRequest)result.AsyncState;
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.EndGetResponse(result);
                Stream stream = resp.GetResponseStream();
                StreamReader r = new StreamReader(resp.GetResponseStream());
                string xml = r.ReadToEnd();
                r.Dispose();

                ParseMirrors(xml);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Failed to download or parse mirrors: " + e.Message);
            }
        }

        /// <summary>
        /// Parses the mirror sites Xml
        /// </summary>
        /// <param name="xml">The Xml containing the mirrors</param>
        private bool ParseMirrors(string xml)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch (XmlException e)
            {
                Console.Error.WriteLine("Failed to get TvDB mirrors: " + e.Message);
                return false;
            }

            foreach (XmlNode mirrorNode in doc.GetElementsByTagName("Mirror"))
            {
                
                TvDBMirror mirror = new TvDBMirror
                    (
                        XmlConvert.ToInt32(mirrorNode["id"].InnerText),
                        mirrorNode["mirrorpath"].InnerText,
                        XmlConvert.ToUInt32(mirrorNode["typemask"].InnerText)
                    );

                _mirrors.Add(mirror);
            }

            return _mirrors.Count > 0;
        }

        /// <summary>
        /// Returns a random mirror that is capable of processing the
        /// given type of request
        /// </summary>
        /// <param name="type">The type or request data that we will
        /// retrieve from the mirror</param>
        /// <returns>A random mirror</returns>
        public TvDBMirror GetMirror(MirrorType type)
        {
            List<TvDBMirror> validMirrors = new List<TvDBMirror>();

            foreach (TvDBMirror mirror in _mirrors)
            {
                if (mirror.ValidType(type))
                    validMirrors.Add(mirror);
            }

            if (validMirrors.Count > 0)
            {
                Random rnd = new Random();
                return validMirrors[rnd.Next(validMirrors.Count)];
            }
            else
            {
                throw new TvDBException("No valid mirror for type: " + type.ToString());
            }
        }


        /// <summary>
        /// Returns the results of searching for a TV show name
        /// </summary>
        /// <param name="title">The title of the TV show</param>
        /// <returns>A list of search results</returns>
        public List<TvDBSearchResult> Search(string title)
        {
            string encTitle = System.Uri.EscapeUriString(title).Replace("%20", "+");

            string url = ApiUrl + "/api/GetSeries.php?seriesname=" + encTitle;

            string xml = GetFile(url);

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch (XmlException e)
            {
                Console.Error.WriteLine("Invalid search xml: " + e.Message);
                return null;
            }

            List<TvDBSearchResult> results = new List<TvDBSearchResult>();

            foreach (XmlNode seriesNode in doc.GetElementsByTagName("Series"))
            {
                try
                {
                    TvDBSearchResult result = new TvDBSearchResult(seriesNode);
                    results.Add(result);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Failed to parse Series node");
                }
            }

            return results;
        }

        /// <summary>
        /// Get the Xml that repesents a full TV show
        /// </summary>
        /// <param name="seriesID">The unique series ID</param>
        /// <returns>The parsed TV show</returns>
        public TvDBShow GetShow(int seriesID)
        {
            TvDBMirror mirror = GetMirror(MirrorType.XmlFiles);
            if (mirror == null)
            {
                Console.Error.WriteLine("Failed to GetShow: No available mirrors");
                return null;
            }

            string url = mirror.Url + "/api/" + ApiKey + "/series/" + 
                         seriesID.ToString() + "/all/" + Language + ".xml";

            string xml = GetFile(url);

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(xml);
                XmlNodeList seriesNodes = doc.GetElementsByTagName("Series");
                if (seriesNodes.Count != 1)
                    Console.Error.WriteLine("Series lookup returned " + seriesNodes.Count.ToString() + " nodes");

                TvDBShow show = new TvDBShow(seriesNodes[0]);
                foreach (XmlNode episodeNode in doc.GetElementsByTagName("Episode"))
                {
                    show.AddEpisode(episodeNode);
                }

                return show;

            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Failed to get show: " + e.Message);
            }

            return null;
        }

        

        /// <summary>
        /// Downloads a remote file
        /// </summary>
        /// <param name="url">The URL to download</param>
        /// <returns>The contents of the remote file</returns>
        private string GetFile(string url)
        {
            Console.Out.WriteLine("Downloading: " + url);
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 5 * 1000;
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();
                StreamReader r = new StreamReader(resp.GetResponseStream());
                string xml = r.ReadToEnd();
                r.Dispose();

                return xml;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Failed to download: " + e.Message);
                return String.Empty;
            }
        }

    }


    /// <summary>
    /// Encapsulates the details for a TV DB API mirror site
    /// </summary>
    public class TvDBMirror
    {
        #region Member Variables

        private string _url = String.Empty;
        private MirrorType _typeMask;
        private int _id;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sEts the mirror URL
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /// <summary>
        /// Gets or sets the type mask for the mirror
        /// </summary>
        public MirrorType TypeMask
        {
            get { return _typeMask; }
            set { _typeMask = value; }
        }

        /// <summary>
        /// Gets or sets the ID number for the mirror
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion

        public TvDBMirror(int id, string url, uint typeMask)
        {
            ID = id;
            Url = url;
            TypeMask = (MirrorType)typeMask;
            
        }

        public TvDBMirror(int id, string url, MirrorType typeMask)
        {
            ID = id;
            TypeMask = typeMask;
            Url = url;
        }

        /// <summary>
        /// Checks if the mirror can handle requests for the given type of data
        /// </summary>
        /// <param name="type">The type of data to retreive from the mirror</param>
        /// <returns>True if the mirror can handle the data, false otherwise</returns>
        public bool ValidType(MirrorType type)
        {
            return ((TypeMask & type) == type);
        }
    }
}
