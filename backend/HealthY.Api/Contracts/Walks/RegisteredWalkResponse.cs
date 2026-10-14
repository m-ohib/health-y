namespace HealthY.Api.Contracts.Walks;

/// <summary>Svaret efter en ny tur: turen og rosebeskeden (US 12).</summary>
public record RegisteredWalkResponse(WalkDto Walk, string Praise);
