using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Elasticsearch.Maping
{
    public  class LogDocument    
    {
        public string TracklogAddres { get; set; }

        public string SuburbName { get; set; }

        public long ElapsedMilliseconds { get; set; }

        public int TracklogId { get; set; }

        public GeoLocation Location { get; set; }
    }
}
