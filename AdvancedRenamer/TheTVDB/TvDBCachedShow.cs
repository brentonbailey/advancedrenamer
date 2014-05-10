using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedRenamer.TheTVDB
{
    public class TvDBCachedShow
    {
        /// <summary>
        /// Get the date the object was cached at
        /// </summary>
        public DateTime CachedAt { get; private set; }

        /// <summary>
        /// Get the show object
        /// </summary>
        public TvDBShow Show { get; private set; }

        public TvDBCachedShow(TvDBShow show)
        {
            CachedAt = DateTime.Now;
            Show = show;
        }
    }
}
