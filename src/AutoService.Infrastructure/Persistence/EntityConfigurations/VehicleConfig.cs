using AutoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoService.Infrastructure.Persistence.EntityConfigurations
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(v => v.Model)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(v => v.Plate)
               .HasMaxLength(10)
               .IsRequired();

            builder.Property(v => v.Color)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(v => new { v.Id, v.Name })
                .IsUnique();
        }
    }
}
