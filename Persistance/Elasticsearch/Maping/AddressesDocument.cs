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

        [Number(NumberType.Float, Name = nameof(Lon), Index = true)]
        public decimal? Lon { get; set; }

        [Number(NumberType.Float, Name = nameof(Lat), Index = true)]
        public decimal? Lat { get; set; }
    }
}
