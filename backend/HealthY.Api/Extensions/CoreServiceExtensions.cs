using HealthY.Core.Accounts;
using HealthY.Core.Common;
using HealthY.Core.Goals;
using HealthY.Core.Praise;
using HealthY.Core.Recipes;
using HealthY.Core.Steps;
using HealthY.Core.Streaks;
using HealthY.Core.Summary;
using HealthY.Core.Walks;

namespace HealthY.Api.Extensions;

/// <summary>
/// Registrerer alle Core-services. Ny service? Tilføj den her.
/// </summary>
public static class CoreServiceExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // Rene beregninger uden tilstand kan være Singleton.
        services.AddSingleton<IStreakService, StreakService>();
        services.AddSingleton<IStepEstimator, StepEstimator>();

        // Services, der bruger repositories (og dermed DbContext), skal være Scoped: én per request.
        services.AddScoped<IWalkService, WalkService>();
        services.AddScoped<IGoalService, GoalService>();
        services.AddScoped<IPraiseService, PraiseService>();
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<ISummaryService, SummaryService>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }
}
