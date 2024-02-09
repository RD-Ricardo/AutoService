using AutoService.Core.Data;
using AutoService.ProfessionalAccount.Domain.Entities;
using AutoService.ProfessionalAccount.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoService.ProfessionalAccount.Infrastructure.Persistence.Repostiories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly ProfessionalAccountDbContext _context;
        public ProfessionalRepository(ProfessionalAccountDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public Task<Professional> FindByEmailAsync(string email)
        {
            return _context.Professionals.SingleOrDefaultAsync(p => p.Email.Equals(email));
        }

        public Task<Professional> FindByIdAsync(Guid id)
        {
            return _context.Professionals.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public Task<Professional> LoginAsync(string email, string passwordHash)
        {
            return _context.Professionals.SingleOrDefaultAsync(p => p.Email.Equals(email) && p.Password.Equals(passwordHash));
        }

        public async Task RegisterAsync(Professional professional)
        {
            await _context.Professionals.AddAsync(professional);
        }

        public Task UpdateAsync(Professional professional)
        {
            throw new NotImplementedException();
        }
    }
}
