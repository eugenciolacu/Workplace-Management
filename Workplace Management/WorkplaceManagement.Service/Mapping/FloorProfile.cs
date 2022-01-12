using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;

namespace WorkplaceManagement.Service.Mapping
{
    class FloorProfile : AutoMapper.Profile
    {
        public FloorProfile()
        {
            CreateMap<Floor, FloorDto>();
            CreateMap<FloorForCreationDto, Floor>();
        }
    }
}
