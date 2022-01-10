using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository     //GenericRepository<Site>, ISiteRepository
    {
        public SiteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
