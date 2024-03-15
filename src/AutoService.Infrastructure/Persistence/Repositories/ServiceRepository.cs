using AutoService.Core.Data;
using AutoService.Domain.Entities;
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

        public async Task CreateServiceAsync(Service service)
        {
            await _dbContext.AddAsync(service);
        }

        public Service UpdateServiceAsync(Service service)
        {
            return _dbContext.Update(service).Entity;
        }
    }
}
