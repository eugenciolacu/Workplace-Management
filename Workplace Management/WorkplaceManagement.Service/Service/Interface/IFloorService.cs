using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.DtoUpdate;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface IFloorService
    {
        void DeleteFloor(long siteId, long id, bool trackChanges);

        public FloorDto GetFloor(long siteId, long id, bool trackChanges);

        IEnumerable<FloorDto> GetFloors(long siteId, bool trackChanges);

        FloorDto CreateFloor(long siteId, FloorForCreationDto floor);

        FloorDto UpdateFloorForSite(long siteId, long id, FloorForUpdateDto floor, bool trackChanges);

        FloorDto PartiallyUpdateFloorForSite(long siteId, long id, JsonPatchDocument<FloorForUpdateDto> patchDoc, bool trackChanges);
    }
}
