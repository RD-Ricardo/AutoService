using AutoService.Payment.Domain.Entities;

namespace AutoService.Payment.Infrastructure.Facade
{
    public interface IPaymentFacade
    {
        Task<Transaction> AuthorizeTransaction(Domain.Entities.Payment payment);
    }
}
