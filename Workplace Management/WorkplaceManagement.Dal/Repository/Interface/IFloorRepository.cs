using System.Collections.Generic;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Interface
{
    public interface IFloorRepository
    {
        IEnumerable<Floor> GetFloors(long siteId, bool trackChanges);

        Floor GetFloor(long siteId, long id, bool trackChanges);

        void CreateFloor(long siteId, Floor floor);

        void DeleteFloor(Floor floor);
    }
}
