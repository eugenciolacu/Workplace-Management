using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeerepository;

        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeerepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> DeleteEmployee(long id)
        {
            Employee toDelete = await _employeerepository.GetAsync(id);
            await _employeerepository.DeleteAsync(toDelete);

            return _mapper.Map<EmployeeDto>(toDelete);
        }

        public async Task<EmployeeDto> GetEmployee(long id)
        {
            Employee result = await _employeerepository.GetAsync(id);

            if (result == null)
            {
                throw new Exception("Employee not found, implement separate exception later");
            }

            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            ICollection<Employee> result = await _employeerepository.GetAllAsync();

            return _mapper.Map<List<EmployeeDto>>(result);
        }

        public async Task<EmployeeDto> PostEmployee(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);

            Employee result = await _employeerepository.AddAsync(employee);

            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<EmployeeDto> PutEmployee(long id, EmployeeDto employeeDto)
        {
            Employee toUpdate = await _employeerepository.GetAsync(id);
            toUpdate.FirstName = employeeDto.FirstName;
            toUpdate.LastName = employeeDto.LastName;
            toUpdate.Email = employeeDto.Email;

            Employee result = await _employeerepository.UpdateAsync(toUpdate, toUpdate.Id);

            return _mapper.Map<EmployeeDto>(result);
        }
    }
}
