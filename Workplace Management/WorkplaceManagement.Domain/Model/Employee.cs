using System.Collections.Generic;

namespace WorkplaceManagement.Domain.Model
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Reservation> Reservations { get; set; } = new();
    }
}
