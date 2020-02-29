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
using System.Diagnostics;
using Microsoft.Extensions.Logging;

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
        ILogger _logger;

        public IndexController(IContext context, ElasticClient elasticClient, IConfiguration configuration, ILogger<Startup> logger)
        {
            _context = context;
            _elasticClient = elasticClient;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost()]
        [Route("")]
        public async Task<IActionResult> PostAsync()
        {

            await Test();

            //string indexName = _configuration["elasticsearch:index"];

            //var index = await _elasticClient.Indices.ExistsAsync(indexName);

            //if (index.Exists)
            //{
            //    await _elasticClient.Indices.DeleteAsync(indexName);
            //}            

            //var createResult =
            //    await _elasticClient.Indices.CreateAsync(indexName, c => c
            //        .Settings(s => s
            //            .Analysis(a => a
            //                .AddSearchAnalyzer()
            //            )
            //        )
            //    .Map<AddressesDocument>(m => m.AutoMap())
            //);

            //int skip = 0;

            //int count = await _context.Addresses.Where(x => x.Lat != null && x.Lon != null).CountAsync();

            //do
            //{

            //    var addreses = await _context.Addresses.Where(x => x.Lat != null && x.Lon != null).Skip(skip).Take(100000).ToListAsync();

            //    var addresesDocument = addreses.Select(x => new AddressesDocument
            //    {
            //        AddressId = x.AddressId,
            //        AddressString = x.AddressString,
            //        Location = new GeoLocation(x.Lat.GetValueOrDefault(), x.Lon.GetValueOrDefault())
            //    }).ToList();

            //    var bullkResult =
            //        await _elasticClient
            //        .BulkAsync(b => b
            //            .Index(indexName)
            //            .CreateMany(addresesDocument)
            //        );

            //    skip += 100000;
            //}
            //while (count > skip);

            //addreses = await _context.Addresses.Skip(20000).Take(20000).ToListAsync();



            //var geoResult = _elasticClient.Search<AddressesDocument>(s => s.From(0).Size(10000)
            //    .Query(query => query
            //        .Bool(b => b.Filter(filter => filter
            //            .GeoDistance(geo => geo
            //                .Field(f => f.Location) //<- this 
            //                .Distance(1400, Nest.DistanceUnit.Kilometers).Location(40, 40)))
            //        )
            //    )
            //);

            return Ok();
        }

        public async Task Test()
        {
            string indexName = "address4";

            var cumulativ = new Stopwatch();
            cumulativ.Start();

            var searchResults2 = _elasticClient.Search<TracklogDocument>(s => s.From(0).Size(10000)
                .Index("tracklog")
                .Query(q => q
                    .MatchAll()
                )
            );

            var logList = new List<LogDocument>();

            foreach (var val in searchResults2.Documents)
            {
                var watch = new Stopwatch();
                watch.Start();
                var geoResult = _elasticClient.Search<SuburbDocument>(s => s.From(0).Size(10000)
                    .Index(indexName)
                    .Query(query => query
                        .Bool(b => b.Filter(filter => filter
                            .GeoDistance(geo => geo
                                .Field(f => f.Location)
                                .Distance(50, Nest.DistanceUnit.Meters).Location(new GeoCoordinate(val.Location.Latitude, val.Location.Longitude)))
                            )
                        )                        
                    )
                    .Sort(s => s
                        .GeoDistance(g => g
                            .Field(p => p.Location)
                            .DistanceType(GeoDistanceType.Arc)
                            .Order(SortOrder.Ascending)
                            .Unit(DistanceUnit.Kilometers)
                            .Points(new GeoCoordinate(val.Location.Latitude, val.Location.Longitude), new GeoCoordinate(val.Location.Latitude, val.Location.Longitude))
                        )
                    )
                );
                watch.Stop();

                var elapsedMs = watch.ElapsedMilliseconds;

                if (geoResult.Documents.Count() > 0 &&  val.Address != geoResult.Documents.FirstOrDefault()?.Name)
                {
                    var log = new LogDocument
                    {
                        ElapsedMilliseconds = elapsedMs,
                        SuburbName = geoResult.Documents.FirstOrDefault()?.Name,
                        TracklogAddres = val.Address,
                        Location = new GeoCoordinate(val.Location.Latitude, val.Location.Longitude),
                        TracklogId = val.TracklogId
                    };
                    logList.Add(log);
                }
            }

            cumulativ.Stop();

            _logger.LogInformation($"Vrijeame trajanje u milisekundama = {cumulativ.ElapsedMilliseconds}");

            var index = await _elasticClient.Indices.ExistsAsync("log");

            if (index.Exists)
            {
                await _elasticClient.Indices.DeleteAsync("log");
            }

            var createResult =
                await _elasticClient.Indices.CreateAsync("log", c => c
                    .Settings(s => s
                        .Analysis(a => a
                            .AddSearchAnalyzer()
                        )
                    )
                .Map<LogDocument>(m => m.AutoMap())
            );


            var bullkResult =
                await _elasticClient                
                .BulkAsync(b => b
                    .Index("log")
                    .CreateMany(logList)
                );


            //var test = new TestDocument
            //{
            //    Id = 1,
            //    Name = "Klocna je klocna"
            //};

            //var res = await  _elasticClient.IndexAsync(test, i => i.Index(indexName));


            //res = await _elasticClient.IndexAsync(new IndexRequest<TestDocument>(test, indexName));

            //var searchResponse = _elasticClient.Search<TestDocument>(s => s
            //    .Index(indexName) 
            //    .From(0)
            //     .Size(10)
            //     .Query(q => q
            //          .Match(m => m
            //             .Field(f => f.Name)
            //             .Query("Klocna je klocna")
            //          )
            //     )
            //);


            // var searchResponse = _elasticClient.Search<TestDocument>(s => s
            //     .Index(indexName)
            //     .Query(q => q
            //        .Match(m => m
            //            .Field(f => f.Name)
            //            .Query("Klocna")
            //        )
            //    )
            //);

           var kloc = "";
        }
    }
}
