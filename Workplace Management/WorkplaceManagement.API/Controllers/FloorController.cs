using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.Dto;
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

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Post([FromBody] FloorDto floor)
        {
            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] FloorDto floor)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<FloorDto> result = _floorService.DeleteFloor(id);

            return Ok(await result);
        }
    }
}
