using HealthY.Core.Goals;
using HealthY.Core.Praise;
using HealthY.Core.Recipes;
using HealthY.Core.Walks;
using HealthY.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthY.Infrastructure.Data;

/// <summary>
/// Forbindelsen til databasen. Kun Infrastructure kender den. Services i Core bruger repositories.
/// </summary>
public class HealthYDbContext(DbContextOptions<HealthYDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Walk> Walks => Set<Walk>();

    public DbSet<Goal> Goals => Set<Goal>();

    public DbSet<Recipe> Recipes => Set<Recipe>();

    public DbSet<PraiseMessage> PraiseMessages => Set<PraiseMessage>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Identity skal sætte sine egne tabeller op først.
        base.OnModelCreating(builder);

        // Finder alle IEntityTypeConfiguration-klasser i mappen Data/Configurations.
        builder.ApplyConfigurationsFromAssembly(typeof(HealthYDbContext).Assembly);
    }
}
