using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Interface
{
    public interface ISiteService
    {
        Task<SiteDto> DeleteSite(long id);

        Task<SiteDto> GetSite(long id);

        Task<IEnumerable<SiteDto>> GetSites();

        Task<SiteDto> PostSite(SiteDto site);

        Task<SiteDto> PutSite(long id, SiteDto site);
    }
}
