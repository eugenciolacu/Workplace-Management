using System.Collections.Generic;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.DtoUpdate;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface ISiteService
    {
        void DeleteSite(long id, bool trackChanges);

        SiteDto GetSite(long id, bool trackChanges);

        IEnumerable<SiteDto> GetSites(bool trackChanges);

        SiteDto CreateSite(SiteForCreationDto site);

        IEnumerable<SiteDto> CreateSiteCollection(IEnumerable<SiteForCreationDto> siteCollection);

        SiteDto UpdateSite(long id, SiteForUpdateDto site, bool trackChanges);

        IEnumerable<SiteDto> GetSiteCollection(IEnumerable<long> ids, bool trackChanges);
    }
}
