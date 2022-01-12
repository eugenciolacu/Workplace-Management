using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IWorkplaceService _workplaceService;

        public WorkplaceController(ILoggerManager logger, IWorkplaceService workplaceService)
        {
            _logger = logger;
            _workplaceService = workplaceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _workplaceService.GetWorkplaces());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _workplaceService.GetWorkplace(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkplaceDto workplace)
        {
            Task<WorkplaceDto> result = Task.Run(async () => await _workplaceService.PostWorkplace(workplace));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, await result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] WorkplaceDto workplace)
        {
            Task<WorkplaceDto> result = _workplaceService.PutWorkplace(id, workplace);

            return CreatedAtAction(nameof(Get), new { id = id }, await result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<WorkplaceDto> result = _workplaceService.DeleteWorkplace(id);

            return Ok(await result);
        }
    }
}
