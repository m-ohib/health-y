namespace HealthY.Core.Recipes;

public interface IRecipeService
{
    /// <summary>Ren beregning: hvilken ret hører til datoen?</summary>
    Recipe? PickForDate(IReadOnlyList<Recipe> recipes, DateOnly date);

    Task<Recipe?> GetTodaysRecipeAsync();
}
