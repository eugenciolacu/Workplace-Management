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
    public class ReservationController : ControllerBase
    {
        private ILoggerManager _logger;
        private IReservationService _reservationService;

        public ReservationController(ILoggerManager logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reservationService.GetReservations());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _reservationService.GetReservation(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservationDto reservation)
        {
            Task<ReservationDto> result = Task.Run(async () => await _reservationService.PostReservation(reservation));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, await result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ReservationDto reservation)
        {
            Task<ReservationDto> result = _reservationService.PutReservation(id, reservation);

            return CreatedAtAction(nameof(Get), new { id = id }, await result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Task<ReservationDto> result = _reservationService.DeleteReservation(id);

            return Ok(await result);
        }
    }
}
