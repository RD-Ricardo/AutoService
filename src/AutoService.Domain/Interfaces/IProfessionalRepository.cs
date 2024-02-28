using AutoService.Core.Data;
using AutoService.Domain.Entities;

namespace AutoService.Domain.Interfaces
{
    public interface IProfessionalRepository : IRepository<Professional>
    {
        Task CreateAsync(Professional professional);
        Task<Professional> LoginAsync(string email, string passwordHash);
        Task<Professional> FindByIdAsync(Guid professionalId);
    }
}
