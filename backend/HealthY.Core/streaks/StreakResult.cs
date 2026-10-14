namespace HealthY.Core.Streaks;

/// <param name="Current">Dage i træk med mindst én tur, til og med i dag eller i går.</param>
/// <param name="Best">Den længste streak nogensinde.</param>
/// <param name="WalkedToday">Om der allerede er gået i dag.</param>
public record StreakResult(int Current, int Best, bool WalkedToday);
