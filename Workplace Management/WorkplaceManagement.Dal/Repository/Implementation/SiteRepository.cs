using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Infrastructure.Context;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class SiteRepository : GenericRepository<Site>, ISiteRepository
    {
        public SiteRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
