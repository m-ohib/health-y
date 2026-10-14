using System.ComponentModel.DataAnnotations;

namespace HealthY.Api.Contracts.Auth;

public record RegisterRequest(
    [Required(ErrorMessage = "Skriv din e-mail.")]
    [EmailAddress(ErrorMessage = "Det ligner ikke en e-mail.")]
    string Email,

    [Required(ErrorMessage = "Skriv en adgangskode.")]
    [MinLength(8, ErrorMessage = "Adgangskoden skal være mindst 8 tegn.")]
    string Password,

    int? BirthYear);
