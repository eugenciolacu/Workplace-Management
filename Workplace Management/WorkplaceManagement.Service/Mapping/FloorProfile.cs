using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Mapping
{
    class FloorProfile : AutoMapper.Profile
    {
        public FloorProfile()
        {
            CreateMap<FloorDto, Floor>();
            CreateMap<Floor, FloorDto>();
        }
    }
}
