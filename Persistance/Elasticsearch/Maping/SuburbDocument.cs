using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Elasticsearch.Maping
{
    public class SuburbDocument
    {
        public dynamic Location { get; set; }

        //  public int Id { get; set; }

        public string Name { get; set; }

        //  public AustralianState State { get; set; }
    }
}

