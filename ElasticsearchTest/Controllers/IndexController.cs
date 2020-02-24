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
        [HttpPost()]
        [Route("")]
        public async Task<IActionResult> PostAsync()
        {

            //var url = configuration["elasticsearch:url"];
            //var defaultIndex = configuration["elasticsearch:index"];

            //using (var db = new Context())
            //{                
            //    var repDataDrivers = db.RepDataDrivers.Take(50);
            //    var kloc = await repDataDrivers.ToArrayAsync();

            //    repDataDrivers = db.RepDataDrivers.Skip(10).Take(50);
            //    kloc = await repDataDrivers.ToArrayAsync();
            //}
            return Ok();
        }        
    }
}
