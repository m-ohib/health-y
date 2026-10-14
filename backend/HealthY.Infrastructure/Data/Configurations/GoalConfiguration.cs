using HealthY.Core.Goals;
using HealthY.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthY.Infrastructure.Data.Configurations;

public class GoalConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        // TODO: Unikt index på UserId, så hver bruger kun kan have ét mål: builder.HasIndex(g => g.UserId).IsUnique();
        // TODO: Gem Type som tekst ("Minutes"/"Steps") i stedet for et tal: builder.Property(g => g.Type).HasConversion<string>();
        // TODO: Fremmednøgle til ApplicationUser med cascade delete (som i WalkConfiguration).
    }
}
