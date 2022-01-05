using System;

namespace WorkplaceManagement.Service.Dto
{
    public class ReservationDto
    {
        public DateTime StratTimestamp { get; set; }
        public Nullable<DateTime> EndTimestamp { get; set; }

        public long WorkplaceId { get; set; }
        public long EmployeeId { get; set; }
    }
}
