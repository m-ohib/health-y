using HealthY.Core.Accounts;
using HealthY.Core.Auth;
using HealthY.Core.Common;
using HealthY.Core.Goals;
using HealthY.Core.Praise;
using HealthY.Core.Recipes;
using HealthY.Core.Walks;
using HealthY.Infrastructure.Auth;
using HealthY.Infrastructure.Data;
using HealthY.Infrastructure.Identity;
using HealthY.Infrastructure.Randomness;
using HealthY.Infrastructure.Repositories;
using HealthY.Infrastructure.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthY.Infrastructure;

/// <summary>
/// Registrerer alt fra Infrastructure ét sted, så Program.cs bare kalder AddInfrastructure().
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // TIP: Connection string sættes lokalt med user-secrets eller appsettings.Development.json (LocalDB),
        //      og i Azure som en "Connection string" på App Service. Aldrig et rigtigt password i git.
        services.AddDbContext<HealthYDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("HealthY")));

        services.AddIdentityCore<ApplicationUser>(options =>
            {
                // US 1: adgangskode på mindst 8 tegn. Ikke krav om tal/tegn/store bogstaver, så Birgit kan være med.
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<HealthYDbContext>();

        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        services.AddScoped<JwtTokenGenerator>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<IClock, DanishClock>();
        services.AddSingleton<IRandomPicker, RandomPicker>();

        services.AddScoped<IWalkRepository, WalkRepository>();
        services.AddScoped<IGoalRepository, GoalRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<IPraiseMessageRepository, PraiseMessageRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }
}
