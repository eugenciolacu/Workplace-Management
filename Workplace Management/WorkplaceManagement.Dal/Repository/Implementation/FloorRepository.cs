using System.Collections.Generic;
using System.Linq;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class FloorRepository : RepositoryBase<Floor>, IFloorRepository
    {
        public FloorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<Floor> GetFloors(long siteId, bool trackChanges)
        {
            return FindByCondition(f => f.SiteId.Equals(siteId), trackChanges)
                .OrderBy(f => f.Name);
        }

        public Floor GetFloor(long siteId, long id, bool trackChanges)
        {
            return FindByCondition(f => f.SiteId.Equals(siteId) && f.Id.Equals(id), trackChanges)
                .SingleOrDefault();
        }
    }
}
