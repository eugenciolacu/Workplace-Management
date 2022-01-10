using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository // GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
