using HealthY.Core.Auth;
using HealthY.Core.Common;
using HealthY.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace HealthY.Infrastructure.Auth;

/// <summary>
/// Oprettelse og login med ASP.NET Core Identity (US 1 og 2).
/// </summary>
public class AuthService(
    UserManager<ApplicationUser> users,
    JwtTokenGenerator tokens,
    IClock clock) : IAuthService
{
    public Task<AuthResult> RegisterAsync(string email, string password, int? birthYear)
    {
        // TODO: 1. Lav en ApplicationUser med UserName = email, Email = email, BirthYear,
        //          ViewMode = ViewModeRules.Suggest(birthYear, clock.Today.Year) og CreatedAt = clock.UtcNow.
        // TODO: 2. var result = await users.CreateAsync(user, password);
        // TODO: 3. Fejler det: returnér new AuthResult(false, null, "<venlig dansk besked>").
        //          Fx "Der findes allerede en bruger med den e-mail" (DuplicateEmail).
        // TODO: 4. Lykkes det: returnér new AuthResult(true, tokens.CreateToken(user), null), så man er logget ind med det samme.
        throw new NotImplementedException();
    }

    public Task<AuthResult> LoginAsync(string email, string password)
    {
        // TODO: 1. Find brugeren med users.FindByEmailAsync(email).
        // TODO: 2. Tjek adgangskoden med users.CheckPasswordAsync(user, password).
        // TODO: 3. Forkert: returnér ÉN venlig fejl, fx "E-mail eller adgangskode passer ikke" (US 2).
        // TIP (sikkerhed): Samme besked, uanset om e-mailen findes eller ej. Så kan man ikke teste, hvem der har en konto.
        throw new NotImplementedException();
    }
}
