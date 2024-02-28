using AutoService.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Customer.Infrastructure.Persistence
{
    public class CustomerDbContext : DbContext, IUnitOfWork
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base (options) { }
        public DbSet<Domain.Entities.Customer> Customers { get; set; }
        public DbSet<Domain.Entities.Vehicle> Vehicles { get; set; }

        public async Task<bool> Commit()
        {
           return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
