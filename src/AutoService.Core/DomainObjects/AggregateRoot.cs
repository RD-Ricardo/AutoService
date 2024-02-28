using AutoService.Core.Messages;

namespace AutoService.Core.DomainObjects
{
    public abstract class AggregateRoot : Entity
    {
        private List<DomainEvent> DomainEvents { get; set; }
        protected AggregateRoot() : base()
        {
            DomainEvents = new List<DomainEvent>();
        }

        public void AddDomainEvent(DomainEvent domainEvent)
            => DomainEvents.Add(domainEvent);
        public void CleanDomainEvents()
            => DomainEvents.Clear();
        public List<DomainEvent> GetDomainEvents() 
            => DomainEvents;
    }
}
