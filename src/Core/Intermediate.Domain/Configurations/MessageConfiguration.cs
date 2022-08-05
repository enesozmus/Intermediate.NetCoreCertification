using Intermediate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intermediate.Domain.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
     public void Configure(EntityTypeBuilder<Message> builder)
     {
          builder.HasKey(x => x.Id);
          builder.Property(x => x.Text).IsRequired().HasMaxLength(300);
     }
}
