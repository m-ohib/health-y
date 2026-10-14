namespace HealthY.Api.Contracts.Walks;

/// <summary>
/// Det frontenden får at se om en tur. Ikke det samme som Walk-entiteten: fx sendes UserId ikke med.
/// </summary>
/// <param name="EstimatedSteps">Skøn ud fra minutter, når Steps er null (US 13). Vises med "ca.".</param>
public record WalkDto(int Id, DateOnly Date, int Minutes, int? Steps, int? EstimatedSteps, string? Note);
