using Microsoft.AspNetCore.Mvc;
using Persistance.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace ElasticsearchTest.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class IndexController : ControllerBase
    {
        internal IContext _context;
        internal IElasticClient _elasticClient;

        public IndexController(IContext context, IElasticClient elasticClient)
        {
            _context = context;
            _elasticClient = elasticClient;
        }

        [HttpPost()]
        [Route("")]
        public async Task<IActionResult> PostAsync()
        {
            var addreses = await _context.Addresses.Take(20).ToListAsync(); 

            await _elasticClient.IndexDocumentAsync(addreses);

            addreses = await _context.Addresses.Skip(20000).Take(20000).ToListAsync();
            return Ok();
        }
    }
}
