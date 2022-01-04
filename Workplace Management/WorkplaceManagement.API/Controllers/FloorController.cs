using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;
using WorkplaceManagement.Service.Interface;

namespace WorkplaceManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        public IFloorService _floorService;

        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _floorService.GetFloors());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _floorService.GetFloor(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FloorDto floor)
        {
            Task<FloorDto> result = Task.Run(async () => await _floorService.PostFloor(floor));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, await result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] FloorDto floor)
        {
            Task<FloorDto> result = _floorService.PutFloor(id, floor);

            return CreatedAtAction(nameof(Get), new { id = id }, await result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<FloorDto> result = _floorService.DeleteFloor(id);

            return Ok(await result);
        }
    }
}
