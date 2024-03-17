using AutoService.Core.Data;
using AutoService.Domain.Entities;
using AutoService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task Create(Customer customer)
        {
            await _dbContext.AddAsync(customer);
        }

        public Task<Customer> FindByEmail(string email)
        {
           return _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
