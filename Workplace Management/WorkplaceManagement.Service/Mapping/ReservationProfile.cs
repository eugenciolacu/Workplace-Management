using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;

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
