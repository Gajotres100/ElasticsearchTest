using Microsoft.AspNetCore.Mvc;
using Persistance.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElasticsearchTest.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class IndexController : ControllerBase
    {
        internal IContext _context;

        public IndexController(IContext context)
        {
            _context = context;
        }

        [HttpPost()]
        [Route("")]
        public async Task<IActionResult> PostAsync()
        {
            var addreses = await _context.Addresses.Take(50).ToListAsync();
            addreses = await _context.Addresses.Skip(10).Take(50).ToListAsync();
            return Ok();
        }
    }
}
