using AutoService.Core.Data;
using AutoService.ProfessionalAccount.Domain.Entities;

namespace AutoService.ProfessionalAccount.Domain.Interfaces
{
    public interface IProfessionalRepository : IRepository<Professional>
    {
        Task<Professional> LoginAsync(string email, string passwordHash);
        Task RegisterAsync(Professional professional);
        Task UpdateAsync(Professional professional);
        Task<Professional> FindByIdAsync(Guid id);
        Task<Professional> FindByEmailAsync(string email);
    }
}
