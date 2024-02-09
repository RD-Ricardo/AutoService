using AutoService.Core.Data;

namespace AutoService.Payment.Domain.Repositories
{
    public interface IPaymentRepository : IRepository<Domain.Entities.Payment>
    {
        Task CreatePayment(Domain.Entities.Payment payment);
        Task<IEnumerable<Domain.Entities.Payment>> GetPaymentsByProfessioalId(Guid professionalId);
    }
}
