using AutoService.Core.DomainObjects;

namespace AutoService.Domain.Entities
{
    public class Customer : AggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int? Phone { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public Customer(string name, string email, int? phone, Guid professionalId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            ProfessionalId = professionalId;
        }

        //EF
        protected Customer() { }
        public Professional Professional { get; private set; }
    }
}
