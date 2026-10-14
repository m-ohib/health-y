using System.ComponentModel.DataAnnotations;

namespace HealthY.Api.Contracts.Auth;

public record LoginRequest(
    [Required] string Email,
    [Required] string Password);
