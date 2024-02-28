using AutoService.Domain.Entities;
using AutoService.Domain.Enums;
using AutoService.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Facade
{
    public class PaymentPix : IPaymentFacade
    {
        private readonly IPaymentCommunicationService _paymentCommunicationService;
        public PaymentPix(IPaymentCommunicationService paymentCommunicationService)
        {
            _paymentCommunicationService = paymentCommunicationService;
        }

        public async Task<Transaction> AuthorizeTransaction(Domain.Entities.Payment payment)
        {
            var communicationResult = await _paymentCommunicationService.NewPayment(
                payment.CustomerId,
                payment.ProfessionalId.ToString(),
                payment.Value,
                "PIX");

            if (!communicationResult.Success)
                return null;

            return new Transaction("", 0.0m,
                TransactionStatus.Authorized,
                communicationResult.Data.Id,
                "PIX",
                payment.Id);
        }
    }
}
