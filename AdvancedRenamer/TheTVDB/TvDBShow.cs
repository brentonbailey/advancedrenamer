using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AdvancedRenamer.TheTVDB
{
    /// <summary>
    /// Parses the Xml for a TV show returned by www.thetvdb.com
    /// </summary>
    public class TvDBShow
    {
        #region Member Variables

        private int _seriesID;
        private string _title;
        private string _overview;
        private List<TvDBSeason> _seasons = new List<TvDBSeason>();

        #endregion

        #region Properties

        /// <summary>
        /// The tvdb unique ID
        /// </summary>
        public int SeriesID
        {
            get { return _seriesID; }
            private set { _seriesID = value; }
        }

        /// <summary>
        /// The show title
        /// </summary>
        public string Title
        {
            get { return _title; }
            private set { _title = value; }
        }

        /// <summary>
        /// The TV show overview
        /// </summary>
        public string Overview
        {
            get { return _overview; }
            private set { _overview = value; }
        }

        #endregion

        /// <summary>
        /// Constructs the TV show by parsing the Xml returned from www.thetvdb.com
        /// </summary>
        /// <param name="seriesNode">The "Series" xml node</param>
        public TvDBShow(XmlNode seriesNode)
        {
            // Prase the series data
            // TODO: Take all seriew data

            foreach (string name in new string[] { "SeriesID", "id" })
            {
                try
                {
                    SeriesID = XmlConvert.ToInt32(seriesNode["SeriesID"].InnerText);
                    break;
                }
                catch { }
            }

            Title = seriesNode["SeriesName"].InnerText;
            Overview = seriesNode["Overview"].InnerText;

        }

        /// <summary>
        /// Add an episode to the show based on Xml returned from www.thetvdb.com
        /// </summary>
        /// <param name="episodeNode">The "Episode" xml node</param>
        public void AddEpisode(XmlNode episodeNode)
        {
            TvDBEpisode episode = new TvDBEpisode(episodeNode);

            int seasonNumber = episode.SeasonNumber;
            TvDBSeason season = GetSeason(seasonNumber);

            if (season == null)
            {
                season = new TvDBSeason(seasonNumber);
                _seasons.Add(season);
            }

            season.Add(episode);
        }

        /// <summary>
        /// Looksup a season based on the logical season number
        /// </summary>
        /// <param name="seasonNumber">The season number</param>
        /// <returns>The saeason, or null if not found</returns>
        public TvDBSeason GetSeason(int seasonNumber)
        {
            foreach (TvDBSeason season in _seasons)
            {
                if (season.Number == seasonNumber)
                    return season;
            }

            return null;
        }


    }
}
