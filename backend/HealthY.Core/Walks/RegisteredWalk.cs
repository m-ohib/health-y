namespace HealthY.Core.Walks;

/// <summary>
/// Resultatet af at registrere en tur: selve turen og rosebeskeden, der skal vises bagefter (US 12).
/// </summary>
public record RegisteredWalk(Walk Walk, string Praise);
