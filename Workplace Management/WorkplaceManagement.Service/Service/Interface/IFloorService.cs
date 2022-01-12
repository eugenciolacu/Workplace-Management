using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface IFloorService
    {
        Task<FloorDto> DeleteFloor(long id);

        public FloorDto GetFloor(long siteId, long id, bool trackChanges);

        IEnumerable<FloorDto> GetFloors(long siteId, bool trackChanges);

        Task<FloorDto> PostFloor(FloorDto floor);

        Task<FloorDto> PutFloor(long id, FloorDto floor);
    }
}
