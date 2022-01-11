using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface ISiteService
    {
        Task<SiteDto> DeleteSite(long id);

        Task<SiteDto> GetSite(long id);

        IEnumerable<SiteDto> GetAllSites(bool trackChanges);

        Task<SiteDto> PostSite(SiteDto site);

        Task<SiteDto> PutSite(long id, SiteDto site);
    }
}
