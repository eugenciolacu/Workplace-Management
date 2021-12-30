using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Interface;

namespace WorkplaceManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        public ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        // GET: api/<SiteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SiteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SiteController>
        [HttpPost]
        public Site Post([FromBody] Site site)
        {
            Task<Site> task = Task.Run<Site>(async () => await _siteService.PostSite(site));
            return task.Result;
        }

        // PUT api/<SiteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SiteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
