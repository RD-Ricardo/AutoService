using AutoService.Domain.Entities;

namespace AutoService.Infrastructure.Facade
{
    public class CreditCardPayment : IPaymentFacade
    {
        public Task<Transaction> AuthorizeTransaction(Domain.Entities.Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
