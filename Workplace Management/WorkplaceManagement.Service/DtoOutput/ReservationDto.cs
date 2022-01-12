using System;

namespace WorkplaceManagement.Service.DtoOutput
{
    public class ReservationDto
    {
        public DateTime StratTimestamp { get; set; }
        public DateTime? EndTimestamp { get; set; }

        public long WorkplaceId { get; set; }
        public long EmployeeId { get; set; }
    }
}
