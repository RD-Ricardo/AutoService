using AutoService.Core.Abstractions.CQRS;
using MediatR;

namespace AutoService.Customer.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommand : Command<Unit>
    {
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
