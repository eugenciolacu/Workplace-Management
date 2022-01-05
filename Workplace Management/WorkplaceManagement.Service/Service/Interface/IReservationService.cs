using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface IReservationService
    {
        Task<ReservationDto> DeleteReservation(long id);

        Task<ReservationDto> GetReservation(long id);

        Task<IEnumerable<ReservationDto>> GetReservations();

        Task<ReservationDto> PostReservation(ReservationDto reservation);

        Task<ReservationDto> PutReservation(long id, ReservationDto reservation);
    }
}
