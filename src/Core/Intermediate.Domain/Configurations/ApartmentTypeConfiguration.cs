using Intermediate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intermediate.Domain.Configurations;

public class ApartmentTypeConfiguration : IEntityTypeConfiguration<ApartmentType>
{
     public void Configure(EntityTypeBuilder<ApartmentType> builder)
     {
          builder.Property(x => x.Type).IsRequired().HasMaxLength(3);

          #region ForeingKey

          // => Bir apartman tipi silindiğinde daireler silinmemeli.
          builder.HasMany(x => x.Apartments)
               .WithOne(x => x.ApartmentType)
               .HasForeignKey(x => x.ApartmentTypeId)
               .OnDelete(DeleteBehavior.Restrict);
          #endregion
     }
}
