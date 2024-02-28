using AutoService.Core.Abstractions.CQRS;
using AutoService.Payment.Domain.Enums;

namespace AutoService.Payment.Application.Commands.CreatePayment
{
    public class CreatePaymentCommand : Command<bool>
    {
        public Guid ProfessionalId { get; private set; }
        public PaymentTypeEnum PaymentType { get; private set; }
        public decimal Value { get; private set; }
        public string CustomerId { get; private set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
