using System.Collections.Generic;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Interface
{
    public interface ISiteRepository
    {
        IEnumerable<Site> GetSites(bool trackChanges);
        Site GetSite(long id, bool trackChanges);
        void CreateSite(Site site);
    }
}
