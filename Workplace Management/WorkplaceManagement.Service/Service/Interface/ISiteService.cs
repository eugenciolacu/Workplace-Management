using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface ISiteService
    {
        void DeleteSite(long id, bool trackChanges);

        SiteDto GetSite(long id, bool trackChanges);

        IEnumerable<SiteDto> GetSites(bool trackChanges);

        SiteDto CreateSite(SiteForCreationDto site);

        IEnumerable<SiteDto> CreateSiteCollection(IEnumerable<SiteForCreationDto> siteCollection);

        Task<SiteDto> PutSite(long id, SiteDto site);

        IEnumerable<SiteDto> GetSiteCollection(IEnumerable<long> ids, bool trackChanges);
    }
}
