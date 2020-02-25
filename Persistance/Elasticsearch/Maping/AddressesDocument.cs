using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Elasticsearch.Maping
{
    [ElasticsearchType(IdProperty = nameof(AddressId))]
    public class AddressesDocument
    {
        [Number(NumberType.Long, Name = nameof(AddressId), Index = true)]
        public long AddressId { get; set; }

        [Keyword(Name = nameof(AddressString), Index = true)]
        public string AddressString { get; set; }
    
        public GeoLocation Location { get; set; }
    }
}
