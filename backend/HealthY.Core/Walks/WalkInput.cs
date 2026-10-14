namespace HealthY.Core.Walks;

/// <summary>
/// Det brugeren indtaster, når en tur oprettes eller rettes.
/// </summary>
public record WalkInput(DateOnly Date, int Minutes, int? Steps, string? Note);
