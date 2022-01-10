using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class WorkplaceRepository : RepositoryBase<Workplace>, IWorkplaceRepository //GenericRepository<Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
