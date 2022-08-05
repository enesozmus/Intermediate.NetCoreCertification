using Intermediate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intermediate.Domain.Configurations;

public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
     public void Configure(EntityTypeBuilder<Block> builder)
     {
          builder.Property(x => x.BlockName).IsRequired().HasMaxLength(30);
          builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
          builder.Property(x => x.TotalFlats).IsRequired().HasMaxLength(3);
          builder.Property(x => x.TotalFloors).IsRequired().HasMaxLength(4);

          #region ForeingKey

          // => Blok silindiğinde daireler de silinmeli.
          builder.HasMany(x => x.Apartments)
               .WithOne(x => x.Block)
               .HasForeignKey(x => x.BlockId)
               .OnDelete(DeleteBehavior.Cascade);
          #endregion
     }
}
