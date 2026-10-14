using HealthY.Api.Contracts.Auth;
using HealthY.Core.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthY.Api.Controllers;

/// <summary>
/// US 1 og 2. De eneste endpoints, der må kaldes uden login.
/// </summary>
// TIP: En tynd controller: modtag request, kald ÉN service, returnér en DTO. Ingen forretningslogik her.
[ApiController]
[Route("api/auth")]
[AllowAnonymous]
public class AuthController(IAuthService auth) : ControllerBase
{
    [HttpPost("register")]
    public Task<ActionResult<AuthResponse>> Register(RegisterRequest request)
    {
        // TODO: var result = await auth.RegisterAsync(request.Email, request.Password, request.BirthYear);
        //       Lykkedes: return Ok(new AuthResponse(result.Token!));
        //       Fejlede:  return BadRequest(new ProblemDetails { Detail = result.Error });
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public Task<ActionResult<AuthResponse>> Login(LoginRequest request)
    {
        // TODO: Som Register, men med auth.LoginAsync. Forkert login -> return Unauthorized(new ProblemDetails { Detail = result.Error });
        // TIP (sikkerhed): Rate limiting på dette endpoint (AddRateLimiter i Program.cs), så man ikke kan gætte adgangskoder.
        throw new NotImplementedException();
    }
}
