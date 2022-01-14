using System.Collections.Generic;
using WorkplaceManagement.Service.DtoInput;

namespace WorkplaceManagement.Service.DtoUpdate
{
    public class SiteForUpdateDto
    {
        public string Name { get; set; }

        public IEnumerable<FloorForCreationDto> Floors { get; set; }
    }
}
