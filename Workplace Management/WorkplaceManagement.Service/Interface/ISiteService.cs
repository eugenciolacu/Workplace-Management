using System.Threading.Tasks;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Service.Interface
{
    public interface ISiteService
    {
        Task<Site> PostSite(Site site);
    }
}
