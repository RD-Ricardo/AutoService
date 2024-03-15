using AutoService.Core.Data;
using AutoService.Core.DomainObjects;
using AutoService.Core.Messages;
using AutoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutoService.Infrastructure.Persistence
{
    public class AutoServiceDbContext : DbContext, IUnitOfWork
    {
        public AutoServiceDbContext() : base()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entities.Payment> Payments { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }


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
            modelBuilder.Ignore<Entity>();
            modelBuilder.Ignore<AggregateRoot>();
            modelBuilder.Ignore<Event>();

            //modelBuilder.UseCollation("");

            //modelBuilder
            //    .HasSequence<int>("", "");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "server=localhost; port=3306; database=auto_service_db; Uid=root; Pwd=root1234;";
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
    }
}
