using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface IFloorService
    {
        void DeleteFloor(long siteId, long id, bool trackChanges);

        public FloorDto GetFloor(long siteId, long id, bool trackChanges);

        IEnumerable<FloorDto> GetFloors(long siteId, bool trackChanges);

        FloorDto CreateFloor(long siteId, FloorForCreationDto floor);

        Task<FloorDto> PutFloor(long id, FloorDto floor);
    }
}
