using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _siteService.GetSites());
        }

        // GET api/<SiteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _siteService.GetSite(id));
        }

        // POST api/<SiteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SiteDto site)
        {
            Task<SiteDto> result = Task.Run(async () => await _siteService.PostSite(site));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, await result);
        }

        // PUT api/<SiteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] SiteDto site)
        {
            Task<SiteDto> result = _siteService.PutSite(id, site);

            return CreatedAtAction(nameof(Get), new { id = id }, await result);
        }

        // DELETE api/<SiteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<SiteDto> result = _siteService.DeleteSite(id);

            return Ok(await result);
        }
    }
}
