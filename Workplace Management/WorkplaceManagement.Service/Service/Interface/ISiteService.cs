using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface ISiteService
    {
        Task<SiteDto> DeleteSite(long id);

        SiteDto GetSite(long id, bool trackChanges);

        IEnumerable<SiteDto> GetSites(bool trackChanges);

        SiteDto CreateSite(SiteForCreationDto site);

        Task<SiteDto> PutSite(long id, SiteDto site);
    }
}
