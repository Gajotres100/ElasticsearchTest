using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Persistance.EntityFramework.Entitys;
using System;
using System.Collections.Generic;

namespace ElasticsearchTest.Configuration
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex)
                .DefaultMappingFor<Addresses>(m => m                
                .PropertyName(p => p.AddressId, "AddressId")
                .PropertyName(p => p.AddressString, "AddressString")
                .PropertyName(p => p.Lat, "Lat")
                .PropertyName(p => p.Lon, "Lon")
            );

            var client = new ElasticClient();

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
