namespace HealthY.Core.Walks;

/// <summary>
/// En registreret gåtur. Entitet: sendes aldrig direkte ud af API'et (brug WalkDto).
/// </summary>
public class Walk
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public DateOnly Date { get; set; }

    public int Minutes { get; set; }

    /// <summary>Valgfrit. Null betyder, at brugeren ikke har skrevet skridt.</summary>
    public int? Steps { get; set; }

    /// <summary>Valgfri, privat note (højst WalkRules.MaxNoteLength tegn).</summary>
    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    // TIP (v1.1): Her kommer SharedGroupId (int?) til fællesskabet. Vent med at tilføje den.
}
