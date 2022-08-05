using Intermediate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intermediate.Domain.Configurations;

public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
     public void Configure(EntityTypeBuilder<Apartment> builder)
     {
          builder.Property(x => x.Floor).IsRequired().HasMaxLength(3);
          builder.Property(x => x.DoorNumber).IsRequired().HasMaxLength(4);
          builder.Property(x => x.IsAvailable).IsRequired();
     }
}
