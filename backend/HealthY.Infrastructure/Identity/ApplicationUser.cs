using HealthY.Core.Accounts;
using Microsoft.AspNetCore.Identity;

namespace HealthY.Infrastructure.Identity;

/// <summary>
/// Brugeren i databasen. Arver Email, PasswordHash osv. fra IdentityUser, så vi ikke selv skal bygge login.
/// </summary>
// TIP: Dette ER "User"-tabellen fra spec'en. Identity kalder den AspNetUsers.
// TIP: Ligger i Infrastructure (ikke Core), fordi den afhænger af Identity-pakken. Core kender kun UserId (string).
public class ApplicationUser : IdentityUser
{
    public int? BirthYear { get; set; }

    public ViewMode ViewMode { get; set; }

    public DateTime CreatedAt { get; set; }

    // ÅBENT SPØRGSMÅL: Tilføj LastPraiseMessageId (int?), hvis "aldrig samme besked som sidst" skal virke.
}
