﻿using Microsoft.Extensions.Configuration;
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
                .DefaultIndex(defaultIndex);

            services.AddSingleton(settings);

            var client = new ElasticClient();

            services.AddScoped(s =>
            {
                var connectionSettings = s.GetRequiredService<ConnectionSettings>();
                var client = new ElasticClient(connectionSettings);

                return client;
            });
        }
    }
}
