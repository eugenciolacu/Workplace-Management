using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private ILoggerManager _logger;

        private IEmployeeRepository _employeerepository;

        private IMapper _mapper;

        public EmployeeService(ILoggerManager logger, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _logger = logger;
            _employeerepository = employeeRepository;
            _mapper = mapper;
        }

        public Task<EmployeeDto> DeleteEmployee(long id)
        {
            return null;
        }

        public Task<EmployeeDto> GetEmployee(long id)
        {
            return null;
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            return null;
        }

        public Task<EmployeeDto> PostEmployee(EmployeeDto employeeDto)
        {
            return null;
        }

        public Task<EmployeeDto> PutEmployee(long id, EmployeeDto employeeDto)
        {
            return null;
        }
    }
}
