using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class WorkplaceRepository : GenericRepository<Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
