using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Mapping
{
    class WorkplaceProfile : AutoMapper.Profile
    {
        public WorkplaceProfile()
        {
            CreateMap<WorkplaceDto, Workplace>();
            CreateMap<Workplace, WorkplaceDto>();
        }
    }
}
