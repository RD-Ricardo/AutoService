using AutoService.Core.Abstractions.CQRS;
using MediatR;

namespace AutoService.Application.Commands.Professional.ContractFullAccessProfessional
{
    public class ContractFullAccessProfessionalCommand : Command<Unit>
    {
        public Guid ProfessionalId { get; set; }
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
