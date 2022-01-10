using System;

namespace WorkplaceManagement.Domain.Model
{
    public class Reservation : EntityBase
    {
        public DateTime StartTimestamp { get; set; }
        public Nullable<DateTime> EndTimestamp { get; set; }

        public long WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }

        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
