using AutoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoService.Infrastructure.Persistence.EntityConfigurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.ProfessionalId)
               .IsRequired();

            builder.Property(s => s.Value)
               .HasColumnType("decimal(6,2)")
               .IsRequired();

            builder.HasIndex(s => new { s.Id, s.Name })
                .IsUnique();
        }
    }
}
