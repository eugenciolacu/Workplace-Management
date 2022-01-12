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
    public class EmployeeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IEmployeeService _employeeService;

        public EmployeeController(ILoggerManager logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeService.GetEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employee)
        {
            Task<EmployeeDto> result = Task.Run(async () => await _employeeService.PostEmployee(employee));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, await result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EmployeeDto employee)
        {
            Task<EmployeeDto> result = _employeeService.PutEmployee(id, employee);

            return CreatedAtAction(nameof(Get), new { id = id }, await result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<EmployeeDto> result = _employeeService.DeleteEmployee(id);

            return Ok(await result);
        }
    }
}
