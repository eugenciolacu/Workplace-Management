using System.Collections.Generic;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Interface
{
    public interface ISiteRepository
    {
        IEnumerable<Site> GetAllSites(bool trackChanges);
    }
}
