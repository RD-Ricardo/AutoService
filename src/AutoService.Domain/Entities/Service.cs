using AutoService.Core.DomainObjects;

namespace AutoService.Domain.Entities
{
    public sealed class Service : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public Service(string name, string description, decimal value, Guid professionalId)
        {
            Name = name;
            Description = description;
            Value = value;
            ProfessionalId = professionalId;
        }

        //EF
        protected Service() { }
        public Professional Professional { get; private set; }
    }
}
