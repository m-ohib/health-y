namespace HealthY.Core.Auth;

/// <param name="Token">JWT, hvis det lykkedes. Ellers null.</param>
/// <param name="Error">Venlig dansk fejlbesked til brugeren, hvis det mislykkedes.</param>
public record AuthResult(bool Succeeded, string? Token, string? Error);
