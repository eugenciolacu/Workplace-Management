using System.Collections.Generic;

namespace WorkplaceManagement.Domain.Model
{
    public class Site : EntityBase
    {
        public string Name { get; set; }

        public List<Floor> Floors { get; set; } = new();
    }
}
