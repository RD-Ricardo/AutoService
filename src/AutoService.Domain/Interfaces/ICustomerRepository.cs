using AutoService.Core.Data;
using AutoService.Domain.Entities;

namespace AutoService.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Create(Customer customer);
        Task<Customer> FindByEmail(string email);
    }
}
