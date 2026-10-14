using HealthY.Core.Praise;
using HealthY.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthY.Infrastructure.Data.Configurations;

public class PraiseMessageConfiguration : IEntityTypeConfiguration<PraiseMessage>
{
    public void Configure(EntityTypeBuilder<PraiseMessage> builder)
    {
        // TODO: builder.Property(p => p.Category).HasConversion<string>();
        // TODO: builder.Property(p => p.Text).HasMaxLength(300).IsRequired();
        builder.HasData(PraiseMessageSeed.All);
    }
}
