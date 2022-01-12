using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.DtoOutput;

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
