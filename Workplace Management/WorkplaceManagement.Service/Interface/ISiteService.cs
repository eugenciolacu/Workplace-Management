using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Interface
{
    public interface ISiteService
    {
        Task<SiteDto> PostSite(SiteDto site);
    }
}
