namespace HealthY.Core.Streaks;

public interface IStreakService
{
    StreakResult Calculate(IEnumerable<DateOnly> walkDates, DateOnly today);
}
