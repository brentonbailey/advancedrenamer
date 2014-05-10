using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AdvancedRenamer.TheTVDB
{
    /// <summary>
    /// Represents a result returned from a TVDB show search
    /// </summary>
    public class TvDBSearchResult
    {
        #region Member Variables

        private int _seriesId;
        private string _title = String.Empty;
        private string _overview = String.Empty;
        private string _bannderFilename = String.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// The TVDB unique series ID
        /// </summary>
        public int SeriesID
        {
            get { return _seriesId; }
            set { _seriesId = value; }
        }

        /// <summary>
        /// The show title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// A brief overview of the show
        /// </summary>
        public string Overview
        {
            get { return _overview; }
            set { _overview = value; }
        }

        /// <summary>
        /// The Banner filename
        /// </summary>
        public string BannerFilename
        {
            get { return _bannderFilename; }
            set { _bannderFilename = value; }
        }

        #endregion

        /// <summary>
        /// Creates a new search result from the search Xml returned by the TV db GetSeries API
        /// </summary>
        /// <param name="seriesNode">The "Series" Xml node</param>
        public TvDBSearchResult(XmlNode seriesNode)
        {
            SeriesID = XmlConvert.ToInt32(seriesNode["seriesid"].InnerText);
            Title = seriesNode["SeriesName"].InnerText;
            try
            {
                Overview = seriesNode["Overview"].InnerText;
            }
            catch { }

            try
            {
                BannerFilename = seriesNode["banner"].InnerText;
            }
            catch { }
        }

        public override string ToString()
        {
            return Title;
        }

    }
}
