using System.Collections.Generic;
using WorkplaceManagement.Domain.Base;

namespace WorkplaceManagement.Domain.Model
{
    public class Site : EntityBase
    {
        public string Name { get; set; }

        public List<Floor> Floors { get; set; } = new();
    }
}
