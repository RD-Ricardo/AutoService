using AutoService.Core.Data;
using AutoService.Domain.Interfaces;

namespace AutoService.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AutoServiceDbContext _dbContext;
        public ServiceRepository(AutoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => _dbContext;
    }
}
