using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class SiteRepository : GenericRepository<Site>, ISiteRepository
    {
        public SiteRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
