using AutoService.Core.DomainObjects;

namespace AutoService.Domain.Entities
{
    public class Audit : AggregateRoot
    {
        public string System { get; set; }
        public Guid UserId { get; set; }
        public string Browser { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public bool Mobile { get; set; }
    }
}
