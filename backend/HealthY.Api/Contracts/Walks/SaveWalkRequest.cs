using System.ComponentModel.DataAnnotations;
using HealthY.Core.Walks;

namespace HealthY.Api.Contracts.Walks;

/// <summary>
/// Bruges både til at oprette (POST) og rette (PUT) en tur.
/// </summary>
// TIP: Valideringen her giver hurtige fejl til frontenden. WalkService validerer IGEN, fordi Core ikke må stole på,
//      at alle kaldere har valideret (fx tests eller en fremtidig app).
public record SaveWalkRequest(
    DateOnly Date,

    [Range(WalkRules.MinMinutes, WalkRules.MaxMinutes, ErrorMessage = "Minutter skal være mellem 1 og 600.")]
    int Minutes,

    [Range(0, int.MaxValue, ErrorMessage = "Skridt kan ikke være negativt.")]
    int? Steps,

    [MaxLength(WalkRules.MaxNoteLength, ErrorMessage = "Noten må højst være 500 tegn.")]
    string? Note);
