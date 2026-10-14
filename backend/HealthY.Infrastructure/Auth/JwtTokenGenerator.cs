using HealthY.Infrastructure.Identity;
using Microsoft.Extensions.Options;

namespace HealthY.Infrastructure.Auth;

/// <summary>
/// Laver en JWT til en bruger. Ét ansvar: kun token-generering.
/// </summary>
public class JwtTokenGenerator(IOptions<JwtOptions> options)
{
    public string CreateToken(ApplicationUser user)
    {
        // TODO: 1. Lav claims: ClaimTypes.NameIdentifier = user.Id og ClaimTypes.Email = user.Email.
        // TODO: 2. Lav en SymmetricSecurityKey ud fra options.Value.Key og SigningCredentials med HmacSha256.
        // TODO: 3. Lav en JwtSecurityToken med issuer, audience, claims og expires = nu + ExpiresInDays.
        // TODO: 4. Returnér new JwtSecurityTokenHandler().WriteToken(token).
        // TIP: Kræver pakken System.IdentityModel.Tokens.Jwt (følger med JwtBearer i Api, men Infrastructure skal også have den).
        throw new NotImplementedException();
    }
}
