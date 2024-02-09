using Microsoft.EntityFrameworkCore;
using AutoService.ProfessionalAccount.Domain.Entities;
using AutoService.Core.Data;
using AutoService.Core.DomainObjects;

namespace AutoService.ProfessionalAccount.Infrastructure.Persistence
{
    public class ProfessionalAccountDbContext : DbContext, IUnitOfWork
    {
        public ProfessionalAccountDbContext(DbContextOptions<ProfessionalAccountDbContext> options) : base(options) {

            ChangeTracker.AutoDetectChangesEnabled = true;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Professional> Professionals { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
