using AutoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoService.Infrastructure.Persistence.EntityConfigurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(v => v.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.ProfessionalId)
               .IsRequired();

            builder.Property(v => v.Value)
               .HasColumnType<decimal>("decimal(6,2)")
               .IsRequired();

            builder.HasIndex(v => new { v.Id, v.Name })
                .IsUnique();
        }
    }
}
