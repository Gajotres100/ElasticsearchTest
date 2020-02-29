using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Elasticsearch.Maping
{
    public  class LogDtocument    
    {
        public string TracklogAddres { get; set; }

        public string SuburbName { get; set; }

        public long ElapsedMilliseconds { get; set; }
    }
}
