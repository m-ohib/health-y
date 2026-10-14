using HealthY.Core.Walks;
using HealthY.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthY.Infrastructure.Data.Configurations;

/// <summary>
/// Hvordan Walk gemmes i databasen. Holdes her, så Core-entiteten ikke har database-attributter.
/// </summary>
public class WalkConfiguration : IEntityTypeConfiguration<Walk>
{
    public void Configure(EntityTypeBuilder<Walk> builder)
    {
        // TODO: builder.HasKey(w => w.Id);
        // TODO: builder.Property(w => w.Note).HasMaxLength(WalkRules.MaxNoteLength);
        // TODO: builder.Property(w => w.UserId).IsRequired();
        // TODO: Fremmednøgle til brugeren med cascade delete, så alle ture slettes med kontoen (GDPR):
        //       builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(w => w.UserId).OnDelete(DeleteBehavior.Cascade);
        // TODO: Index på (UserId, Date), fordi næsten alle forespørgsler filtrerer på netop det.
    }
}
