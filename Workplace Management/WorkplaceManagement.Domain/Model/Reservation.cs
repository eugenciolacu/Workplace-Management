using System;
using WorkplaceManagement.Domain.Base;

namespace WorkplaceManagement.Domain.Model
{
    public class Reservation : EntityBase
    {
        public DateTime StratTimestamp { get; set; }
        public Nullable<DateTime> EndTimestamp { get; set; }
    }
}
