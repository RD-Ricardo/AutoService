using AutoService.Core.Abstractions.CQRS;
using MediatR;

namespace AutoService.Application.Commands.Service.UpdateService
{
    public class UpdateServiceCommand(string serviceId, string professionalId, string name, string description, decimal value) : Command<Unit>
    {
        public Guid ServiceId { get; private set; } = Guid.Parse(serviceId);
        public Guid ProfessionalId { get; private set; } = Guid.Parse(professionalId);
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public decimal Value { get; private set; } = value;
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
