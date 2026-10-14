using System.ComponentModel.DataAnnotations;
using HealthY.Core.Accounts;

namespace HealthY.Api.Contracts.Account;

public record SettingsDto(
    [Range(1900, 2100, ErrorMessage = "Skriv et gyldigt fødselsår.")]
    int? BirthYear,
    ViewMode ViewMode);
