using AutoService.Core.Data;
using AutoService.Domain.Interfaces;

namespace AutoService.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AutoServiceDbContext _dbContext;
        public PaymentRepository(AutoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;
    }
}
