using AutoService.Core.DomainObjects;
using AutoService.Service.Domain.Enums;

namespace AutoService.Service.Domain.Entities
{
    public class Service : AggregateRoot
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Term { get; set; }
        public ServiceStatus Status { get; set; }
        public Guid ProfessionalId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VehicleId { get; set; }
    }
}
