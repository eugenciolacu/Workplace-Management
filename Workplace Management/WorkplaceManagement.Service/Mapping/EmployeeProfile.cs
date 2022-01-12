using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.DtoOutput;

namespace WorkplaceManagement.Service.Mapping
{
    public class EmployeeProfile : AutoMapper.Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
