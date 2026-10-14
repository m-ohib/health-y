namespace HealthY.Core.Auth;

/// <summary>
/// Oprettelse og login. Implementeres i Infrastructure, fordi det bruger ASP.NET Core Identity.
/// </summary>
public interface IAuthService
{
    /// <summary>US 1: e-mail og adgangskode (mindst 8 tegn). Fødselsår er valgfrit (US 10).</summary>
    Task<AuthResult> RegisterAsync(string email, string password, int? birthYear);

    /// <summary>US 2: returnerer en JWT ved korrekt login.</summary>
    Task<AuthResult> LoginAsync(string email, string password);
}
