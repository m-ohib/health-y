namespace HealthY.Core.Recipes;

public interface IRecipeRepository
{
    /// <summary>Alle retter sorteret efter Id, så rækkefølgen altid er den samme.</summary>
    Task<IReadOnlyList<Recipe>> GetAllAsync();
}
