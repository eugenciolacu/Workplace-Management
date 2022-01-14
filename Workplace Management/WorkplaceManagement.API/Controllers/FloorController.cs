using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.DtoUpdate;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.API.Controllers
{
    [Route("api/sites/{siteId}/floors")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private ILoggerManager _logger;
        private IFloorService _floorService;
        private ISiteService _siteService;

        public FloorController(ILoggerManager logger, IFloorService floorService, ISiteService siteService)
        {
            _logger = logger;
            _floorService = floorService;
            _siteService = siteService;
        }

        [HttpGet]
        public IActionResult GetFloorsForSite(long siteId)
        {
            SiteDto site = _siteService.GetSite(siteId, trackChanges: false);
            if(site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database");
                return NotFound();
            }

            IEnumerable<FloorDto> floors = _floorService.GetFloors(siteId, trackChanges: false);

            return Ok(floors);
        }

        [HttpGet("{id}", Name = "GetFloorForSite")]
        public IActionResult GetFloorForSite(long siteId, long id)
        {
            SiteDto site = _siteService.GetSite(siteId, trackChanges: false);
            if(site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floor = _floorService.GetFloor(siteId, id, trackChanges: false);
            if(floor == null)
            {
                _logger.LogInfo($"Floor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            return Ok(floor);
        }

        [HttpPost]
        public IActionResult CreateFloorForSite(long siteId, [FromBody] FloorForCreationDto floor)
        {
            if (floor == null)
            {
                _logger.LogError("FloorForCreationDto object sent from client is null.");
                return BadRequest("FloorForCreationDto object is null");
            }

            SiteDto site = _siteService.GetSite(siteId, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floorToReturn = _floorService.CreateFloor(siteId, floor);

            return CreatedAtRoute("GetFloorForSite", new { siteId, id = floorToReturn.Id }, floorToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFloorForSite(long siteId, long id, [FromBody] FloorForUpdateDto floor)
        {
            if(floor == null)
            {
                _logger.LogError("FloorForUpdateDto object sent from client is null.");
                return BadRequest("FloorForUpdateDto object is null");
            }

            SiteDto site = _siteService.GetSite(siteId, trackChanges: false);
            if(site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floorToBeUpdated = _floorService.GetFloor(siteId, id, trackChanges: false);
            if (floorToBeUpdated == null)
            {
                _logger.LogInfo($"Floor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _floorService.UpdateFloorForSite(siteId, id, floor, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFloorForSite(long siteId, long id)
        {
            SiteDto site = _siteService.GetSite(siteId, trackChanges: false);

            if(site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database");
                return NotFound();
            }

            FloorDto floorForSite = _floorService.GetFloor(siteId, id, trackChanges: false);

            if(floorForSite == null)
            {
                _logger.LogInfo($"Site with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _floorService.DeleteFloor(siteId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateFloorForSite(long siteId, long id, [FromBody] JsonPatchDocument<FloorForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            SiteDto site = _siteService.GetSite(siteId, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floorToBeUpdated = _floorService.GetFloor(siteId, id, trackChanges: false);

            if (floorToBeUpdated == null)
            {
                _logger.LogInfo($"Floor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _floorService.PartiallyUpdateFloorForSite(siteId, id, patchDoc, true);

            return NoContent();
        }
    }
}
