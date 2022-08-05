using Intermediate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intermediate.Domain.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
     public void Configure(EntityTypeBuilder<Bill> builder)
     {
          builder.Property(x => x.AmountPayable).IsRequired().HasColumnType("decimal(18,2)");
     }
}
