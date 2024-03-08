using AutoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoService.Infrastructure.Persistence.EntityConfigurations
{
    public class ProfessionalConfig : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.CPF)
               .HasMaxLength(11)
               .IsRequired();

            builder.Property(c => c.PhotoDirectory)
                .HasMaxLength(11)
                .IsRequired(false);

            builder.Property(c => c.DateFullAcecss)
                .HasMaxLength(11)
                .IsRequired(false);

            builder.HasIndex(c => new { c.Email, c.Id })
                .IsUnique();
        }
    }
}
