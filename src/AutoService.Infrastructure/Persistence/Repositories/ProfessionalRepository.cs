using AutoService.Core.Data;
using AutoService.Domain.Entities;
using AutoService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Infrastructure.Persistence.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly AutoServiceDbContext _dbContext;
        public ProfessionalRepository(AutoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task CreateAsync(Professional professional)
        {
            await _dbContext.Professionals.AddAsync(professional);
        }

        public Task<Professional> FindByIdAsync(Guid professionalId)
        {
            return _dbContext.Professionals.FirstOrDefaultAsync(x => x.Id == professionalId);
        }

        public Task<Professional> LoginAsync(string email, string passwordHash)
        {
            return _dbContext.Professionals.SingleOrDefaultAsync(p => p.Email == email && p.Password == passwordHash);
        }
    }
}
