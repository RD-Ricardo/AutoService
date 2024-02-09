using AutoService.Core.Data;
using AutoService.Payment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Payment.Infrastructure.Persistence
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _context;
        public PaymentRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task CreatePayment(Domain.Entities.Payment payment)
        {
            _context.Payments.AddAsync(payment);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Domain.Entities.Payment>> GetPaymentsByProfessioalId(Guid professionalId)
        {
            return await _context.Payments.Where(x => x.ProfessionalId  == professionalId)
                .Include(x => x.Transactions)
                .ToListAsync();
        }
    }
}
