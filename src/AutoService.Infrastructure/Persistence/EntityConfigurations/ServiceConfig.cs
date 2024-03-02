using AutoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoService.Infrastructure.Persistence.EntityConfigurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            //builder.HasData(new[] { 

            //        new P
            //} );

            builder.Property(x => x.Id)
                .HasConversion<string>();

            builder
                .HasIndex(s => new { s.Id })
                .IsUnique()
                .HasFilter("Id not null");
        }
    }
}
