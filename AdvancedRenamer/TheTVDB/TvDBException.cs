using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedRenamer.TheTVDB
{
    [Serializable]
    public class TvDBException : Exception
    {
        public TvDBException() { }
        public TvDBException(string message) : base(message) { }
        public TvDBException(string message, Exception inner) : base(message, inner) { }
        protected TvDBException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
