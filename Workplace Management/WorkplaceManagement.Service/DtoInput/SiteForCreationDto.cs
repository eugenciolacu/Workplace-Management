using System.Collections.Generic;

namespace WorkplaceManagement.Service.DtoInput
{
    public class SiteForCreationDto
    {
        public string Name { get; set; }

        public IEnumerable<FloorForCreationDto> Floors { get; set; }
    }
}
