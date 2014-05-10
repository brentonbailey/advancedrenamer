using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AdvancedRenamer.TheTVDB
{
    /// <summary>
    /// Contains attributes of TV episode as stored in thetvdb
    /// </summary>
    public class TvDBEpisode : IComparable<TvDBEpisode>
    {
        private int _number = 0;
        private string _title = String.Empty;
        private string _overview = String.Empty;
        private int _seasonNumber = 0;
        private DateTime _firstAired;

        #region Properties

        /// <summary>
        /// The episode number
        /// </summary>
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        /// <summary>
        /// The episode title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// The episode synopsis
        /// </summary>
        public string Overview
        {
            get { return _overview; }
            set { _overview = value; }
        }

        /// <summary>
        /// The season number
        /// </summary>
        public int SeasonNumber
        {
            get { return _seasonNumber; }
            set { _seasonNumber = value; }
        }

        #endregion

        /// <summary>
        /// Creates an episode based on the Xml returned by www.thetvdb.com
        /// </summary>
        /// <param name="episodeNode">The "Episode" Xml node</param>
        public TvDBEpisode(XmlNode episodeNode)
        {
            // TODO: Add all episode data
            Title = episodeNode["EpisodeName"].InnerText;
            Overview = episodeNode["Overview"].InnerText;
            Number = XmlConvert.ToInt32(episodeNode["EpisodeNumber"].InnerText);
            SeasonNumber = XmlConvert.ToInt32(episodeNode["SeasonNumber"].InnerText);
        }

        #region IComparable<TvDBEpisode> Members

        public int CompareTo(TvDBEpisode other)
        {
            return Number.CompareTo(other.Number);
        }

        #endregion

        /// <summary>
        /// Returns an episode title string.
        /// EG: 1x01 - Pilot
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SeasonNumber.ToString() + "x" +
                   Number.ToString().PadLeft(2, '0') + " - " +
                   Title;
        }
    }
}
