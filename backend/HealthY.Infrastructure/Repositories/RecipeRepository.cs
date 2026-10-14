using HealthY.Core.Recipes;
using HealthY.Infrastructure.Data;

namespace HealthY.Infrastructure.Repositories;

public class RecipeRepository(HealthYDbContext db) : IRecipeRepository
{
    public Task<IReadOnlyList<Recipe>> GetAllAsync()
    {
        // TODO: db.Recipes.AsNoTracking().OrderBy(r => r.Id).ToListAsync()
        // TIP: Listen ændrer sig næsten aldrig. Senere kan den caches med IMemoryCache.
        throw new NotImplementedException();
    }
}
