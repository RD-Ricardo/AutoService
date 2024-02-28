using MediatR;
using AutoService.Core.Abstractions.CQRS;

namespace AutoService.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommand : Command<Unit>
    {
        public override bool Validate()
        {
            return false;
        }
    }
}
