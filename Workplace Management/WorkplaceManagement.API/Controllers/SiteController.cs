using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.API.Controllers
{
    [Route("api/sites")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private ILoggerManager _logger;
        private ISiteService _siteService;

        public SiteController(ILoggerManager logger, ISiteService siteService)
        {
            _logger = logger;
            _siteService = siteService;
        }

        [HttpGet]
        public IActionResult GetSites()
        {
            IEnumerable<SiteDto> sites = _siteService.GetSites(trackChanges: false);

            return Ok(sites);
        }

        [HttpGet("{id}", Name = "SiteById")]
        public IActionResult GetSite(long id)
        {
            SiteDto site = _siteService.GetSite(id, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(site);
            }
        }

        [HttpPost]
        public IActionResult CreateSite([FromBody] SiteForCreationDto site)
        {
            if(site == null)
            {
                _logger.LogError("SiteForCreationDto object sent from client is null");
                return BadRequest("SiteForCreationDto object is null");
            }

            SiteDto siteToReturn = _siteService.CreateSite(site);

            return CreatedAtRoute("SiteById", new { id = siteToReturn.Id }, siteToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] SiteDto site)
        {
            Task<SiteDto> result = _siteService.PutSite(id, site);

            return null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<SiteDto> result = _siteService.DeleteSite(id);

            return Ok(await result);
        }
    }
}
