using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.Dto;
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
            IEnumerable<SiteDto> sites = _siteService.GetAllSites(trackChanges: false);

            return Ok(sites);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _siteService.GetSite(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SiteDto site)
        {
            Task<SiteDto> result = Task.Run(async () => await _siteService.PostSite(site));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, await result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] SiteDto site)
        {
            Task<SiteDto> result = _siteService.PutSite(id, site);

            return CreatedAtAction(nameof(Get), new { id = id }, await result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<SiteDto> result = _siteService.DeleteSite(id);

            return Ok(await result);
        }
    }
}
