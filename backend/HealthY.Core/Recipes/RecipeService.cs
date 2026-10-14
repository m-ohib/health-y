using HealthY.Core.Common;

namespace HealthY.Core.Recipes;

/// <summary>
/// Finder kun dagens ret, intet andet (ét ansvar).
/// </summary>
public class RecipeService(IRecipeRepository recipes, IClock clock) : IRecipeService
{
    public Recipe? PickForDate(IReadOnlyList<Recipe> recipes, DateOnly date)
    {
        // TODO: Returnér null, hvis listen er tom. Ellers recipes[date.DayNumber % recipes.Count].
        // TIP: DayNumber stiger med 1 hver dag, så retten skifter hver dag og starter forfra efter ca. 30 dage.
        //      Samme dato giver altid samme ret, så alle brugere ser den samme (krav i US 11).
        throw new NotImplementedException();
    }

    public Task<Recipe?> GetTodaysRecipeAsync()
    {
        // TODO: Hent alle retter, og returnér PickForDate(retter, clock.Today).
        throw new NotImplementedException();
    }
}
