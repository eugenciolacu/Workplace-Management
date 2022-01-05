using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> DeleteEmployee(long id);

        Task<EmployeeDto> GetEmployee(long id);

        Task<IEnumerable<EmployeeDto>> GetEmployees();

        Task<EmployeeDto> PostEmployee(EmployeeDto employee);

        Task<EmployeeDto> PutEmployee(long id, EmployeeDto employee);
    }
}
