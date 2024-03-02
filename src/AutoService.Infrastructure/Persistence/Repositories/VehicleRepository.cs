using AutoService.Core.Data;
using AutoService.Domain.Interfaces;

namespace AutoService.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AutoServiceDbContext _dbContext;
        public VehicleRepository(AutoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;
    }
}
