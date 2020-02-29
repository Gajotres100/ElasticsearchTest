using GeoAPI.Geometries;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Elasticsearch.Maping
{
    public class SuburbDocument
    {
        public GeoLocation Location { get; set; }

        public string Name { get; set; }
    }
}

