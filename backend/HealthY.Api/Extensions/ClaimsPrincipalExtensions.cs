using System.Security.Claims;

namespace HealthY.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Brugerens id fra JWT'en.
    /// </summary>
    // TIP (sikkerhed): Brug ALTID denne til at finde brugeren. Tag aldrig userId fra URL'en eller request-body,
    //                  for så kan man bare skrive en andens id.
    public static string GetUserId(this ClaimsPrincipal user) =>
        user.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new InvalidOperationException("Brugeren har ikke et id i sit token.");
}
