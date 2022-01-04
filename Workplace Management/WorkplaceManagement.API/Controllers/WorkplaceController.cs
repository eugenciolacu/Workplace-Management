using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;
using WorkplaceManagement.Service.Interface;

namespace WorkplaceManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        public IWorkplaceService _workplaceService;

        public WorkplaceController(IWorkplaceService workplaceService)
        {
            _workplaceService = workplaceService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _workplaceService.GetWorkplaces());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _workplaceService.GetWorkplace(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkplaceDto workplace)
        {
            Task<WorkplaceDto> result = Task.Run(async () => await _workplaceService.PostWorkplace(workplace));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, await result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] WorkplaceDto workplace)
        {
            Task<WorkplaceDto> result = _workplaceService.PutWorkplace(id, workplace);

            return CreatedAtAction(nameof(Get), new { id = id }, await result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<WorkplaceDto> result = _workplaceService.DeleteWorkplace(id);

            return Ok(await result);
        }
    }
}
