using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Web;
using MediatR;

namespace AutoService.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand, Unit>
    {
        public override Task<RequestResult<Unit>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
