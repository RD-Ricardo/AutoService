﻿using AutoService.Core.DomainObjects;

namespace AutoService.Domain.Entities
{
    public sealed class Vehicle : AggregateRoot
    {
        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Plate { get; private set; }
        public string Color { get; set; }
        public int YearManufacture { get; private set; }
        public Guid CustomerId { get; private set; }
        public Vehicle(string name,
            string model,
            string plate,
            string color,
            int yearManufacture,
            Guid customerId)
        {
            Name = name;
            Model = model;
            Plate = plate;
            Color = color;
            YearManufacture = yearManufacture;
            CustomerId = customerId;
        }

        // EF
        public Customer Customer { get; set; }
        protected Vehicle() { }
    }
}
