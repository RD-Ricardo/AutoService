using AutoService.Domain.Entities;

namespace AutoService.Infrastructure.Facade
{
    public interface IPaymentFacade
    {
        Task<Transaction> AuthorizeTransaction(Domain.Entities.Payment payment);
    }
}
