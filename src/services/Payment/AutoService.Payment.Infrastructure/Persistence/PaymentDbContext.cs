using AutoService.Core.Data;
using AutoService.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Payment.Infrastructure.Persistence
{
    public class PaymentDbContext : DbContext, IUnitOfWork
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options): base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Domain.Entities.Payment> Payments { get; set; }

        public async Task<bool> Commit()
        {
            foreach (var entity in ChangeTracker.Entries<Entity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                if (entity.State == EntityState.Added)
                    entity.Entity.SetCreationDate();
                else
                    entity.Entity.SetUpdateDate();
            }

            return await SaveChangesAsync() > 0;
        }
    }
}
