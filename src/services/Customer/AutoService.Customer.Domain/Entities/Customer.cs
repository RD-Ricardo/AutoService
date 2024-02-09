﻿using AutoService.Core.DomainObjects;

namespace AutoService.Customer.Domain.Entities
{
    public class Customer : AggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Phone { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}