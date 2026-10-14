using HealthY.Api.Contracts.Recipes;
using HealthY.Core.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace HealthY.Api.Controllers;

/// <summary>US 11.</summary>
[ApiController]
[Route("api/recipes")]
public class RecipesController(IRecipeService recipes) : ControllerBase
{
    [HttpGet("today")]
    public Task<ActionResult<RecipeDto>> GetToday()
    {
        // TODO: var recipe = await recipes.GetTodaysRecipeAsync();
        //       null -> NotFound(), ellers Ok(new RecipeDto(...)).
        throw new NotImplementedException();
    }
}
