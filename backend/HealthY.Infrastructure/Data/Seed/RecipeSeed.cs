using HealthY.Core.Recipes;

namespace HealthY.Infrastructure.Data.Seed;

/// <summary>
/// Den faste liste med ca. 30 retter (US 11).
/// </summary>
public static class RecipeSeed
{
    public static readonly Recipe[] All =
    [
        // TODO: Tilføj ca. 30 retter. Eksempel:
        // new Recipe { Id = 1, Name = "Ovnbagt laks med rodfrugter", Description = "...", WhyHealthy = "...", ImageUrl = "/images/recipes/laks.jpg" },
        // TIP: Id skal sættes manuelt, når man bruger HasData.
        // TIP: Ingen kalorietal eller diætråd (krav i US 11). Skriv i enkelt sprog.
        // TIP: Brug billeder, I selv har rettighederne til (egne fotos eller fx Unsplash-licens).
    ];
}
