using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.DtoOutput;

namespace WorkplaceManagement.Service.Mapping
{
    class ReservationProfile : AutoMapper.Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>();
        }
    }
}
