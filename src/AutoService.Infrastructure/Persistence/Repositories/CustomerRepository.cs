using AutoService.Core.Data;
using AutoService.Domain.Interfaces;

namespace AutoService.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AutoServiceDbContext _dbContext;
        public CustomerRepository(AutoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;
    }
}
