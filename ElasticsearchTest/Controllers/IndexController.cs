using Microsoft.AspNetCore.Mvc;
using Persistance.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nest;
using Microsoft.Extensions.Configuration;
using Persistance.Elasticsearch.Maping;

namespace ElasticsearchTest.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class IndexController : ControllerBase
    {
        IContext _context;
        ElasticClient _elasticClient;
        IConfiguration _configuration;

        public IndexController(IContext context, ElasticClient elasticClient, IConfiguration configuration)
        {
            _context = context;
            _elasticClient = elasticClient;
            _configuration = configuration;
        }

        [HttpPost()]
        [Route("")]
        public async Task<IActionResult> PostAsync()
        {
            

            string indexName = _configuration["elasticsearch:index"];

            var index = await _elasticClient.Indices.ExistsAsync(indexName);

            if (index.Exists)
            {
                await _elasticClient.Indices.DeleteAsync(indexName);
            }            

            var createResult =
                await _elasticClient.Indices.CreateAsync(indexName, c => c
                    .Settings(s => s
                        .Analysis(a => a
                            .AddSearchAnalyzer()
                        )
                    )
                .Map<AddressesDocument>(m => m.AutoMap())
            );

            int skip = 0;

            int count = await _context.Addresses.CountAsync();

            do
            {

                var addreses = await _context.Addresses.Skip(skip).Take(100000).ToListAsync();

                var addresesDocument = addreses.Select(x => new AddressesDocument
                {
                    AddressId = x.AddressId,
                    AddressString = x.AddressString,
                    Lat = x.Lat,
                    Lon = x.Lon
                }).ToList();

                var bullkResult =
                    await _elasticClient
                    .BulkAsync(b => b
                        .Index(indexName)
                        .CreateMany(addresesDocument)
                    );

                skip += 100000;
            }
            while (count > skip);

            //addreses = await _context.Addresses.Skip(20000).Take(20000).ToListAsync();
            return Ok();
        }
    }
}
