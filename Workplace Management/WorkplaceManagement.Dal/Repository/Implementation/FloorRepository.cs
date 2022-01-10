using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class FloorRepository : RepositoryBase<Floor>, IFloorRepository // GenericRepository<Floor>, IFloorRepository
    {
        public FloorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
