using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Interface;

namespace WorkplaceManagement.Service.Implementation
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }


        public async Task<Site> PostSite(Site site)
        {
            await _siteRepository.AddAsyn(site);
            await _siteRepository.SaveAsync();
            return site;
        }
    }
}
