using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkplaceManagement.API.ModelBinders;
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

        [HttpGet("collection/({ids})", Name = "SiteCollection")]
        public IActionResult GetSiteCollection([FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<long> ids) // without [FromRoute] do not work in swagger
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            IEnumerable<SiteDto> sitesToReturn = _siteService.GetSiteCollection(ids, trackChanges: false);

            if (ids.Count() != sitesToReturn.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            return Ok(sitesToReturn);
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



        [HttpPost("collection")]
        public IActionResult CreateSiteCollection([FromBody] IEnumerable<SiteForCreationDto> siteCollection)
        {
            if (siteCollection == null)
            {
                _logger.LogError("Site collection sent from client is null.");
                return BadRequest("Site collection is null");
            }

            IEnumerable<SiteDto> siteCollectionToReturn = _siteService.CreateSiteCollection(siteCollection);

            string ids = string.Join(",", siteCollectionToReturn.Select(s => s.Id));

            return CreatedAtRoute("SiteCollection", new { ids }, siteCollectionToReturn);
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
