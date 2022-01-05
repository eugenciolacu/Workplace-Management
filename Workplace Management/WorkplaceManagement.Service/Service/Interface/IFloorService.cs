using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface IFloorService
    {
        Task<FloorDto> DeleteFloor(long id);

        Task<FloorDto> GetFloor(long id);

        Task<IEnumerable<FloorDto>> GetFloors();

        Task<FloorDto> PostFloor(FloorDto floor);

        Task<FloorDto> PutFloor(long id, FloorDto floor);
    }
}
