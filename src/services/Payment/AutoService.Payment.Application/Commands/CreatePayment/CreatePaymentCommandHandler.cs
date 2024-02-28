using AutoService.Core.Abstractions.CQRS.Handlers;

namespace AutoService.Payment.Application.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : CommandHandler<CreatePaymentCommand, bool>
    {
        public override Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
