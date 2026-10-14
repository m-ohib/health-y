using HealthY.Core.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthY.Infrastructure.Data.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        // TODO: Sæt maks-længder på Name, Description og WhyHealthy.
        // TODO: builder.HasData(RecipeSeed.All); så de ca. 30 retter kommer med i en migration.
    }
}
