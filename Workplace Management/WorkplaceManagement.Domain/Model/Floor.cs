using WorkplaceManagement.Domain.Base;

namespace WorkplaceManagement.Domain.Model
{
    public class Floor : EntityBase
    {
        public string Name { get; set; }

        public long SiteId { get; set; }
        public Site Site { get; set; }
    }
}
