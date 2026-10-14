namespace HealthY.Core.Streaks;

public interface IStreakService
{
    /// <summary>
    /// Beregner streak ud fra de datoer, brugeren har gået (US 9).
    /// </summary>
    StreakResult Calculate(IEnumerable<DateOnly> walkDates, DateOnly today);
}
