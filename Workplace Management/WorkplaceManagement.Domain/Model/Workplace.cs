using System.Collections.Generic;

namespace WorkplaceManagement.Domain.Model
{
    public class Workplace : EntityBase
    {
        public string Name { get; set; }

        public long FloorId { get; set; }
        public Floor Floor { get; set; }

        public List<Reservation> Reservations { get; set; } = new();
    }
}
