using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedRenamer.TheTVDB
{
    /// <summary>
    /// Contains attributes of a season stored in thetvdb database.
    /// </summary>
    public class TvDBSeason : List<TvDBEpisode>
    {
        private int _number = 0;

        #region Propeties

        /// <summary>
        /// Gets or sets the season
        /// </summary>
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        #endregion

        public TvDBSeason(int seasonNumber)
        {
            Number = seasonNumber;
        }

    }
}
