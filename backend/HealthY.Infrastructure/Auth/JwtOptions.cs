namespace HealthY.Infrastructure.Auth;

/// <summary>
/// Indstillinger til JWT. Læses fra konfigurationen under "Jwt".
/// </summary>
// TIP (sikkerhed): Key må ALDRIG stå i appsettings.json. Lokalt: dotnet user-secrets set "Jwt:Key" "<lang tilfældig nøgle>"
//                  I Azure: en App Service-indstilling med navnet Jwt__Key.
public class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;

    /// <summary>Mindst 32 tegn (256 bit).</summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>Hvor længe man er logget ind. Spec'en siger "forbliv logget ind", så den må gerne være lang.</summary>
    public int ExpiresInDays { get; set; } = 30;
}
