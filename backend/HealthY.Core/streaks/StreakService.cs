namespace HealthY.Core.Streaks;

public class StreakService : IStreakService
{
    public StreakResult Calculate(IEnumerable<DateOnly> walkDates, DateOnly today)
    {
        var days = walkDates.ToHashSet();

        var walkedToday = days.Contains(today);

        var day = walkedToday ? today : today.AddDays(-1);
        var current = 0;
        while (days.Contains(day))
        {
            current++;
            day = day.AddDays(-1);
        }

        var best = 0;
        var run = 0;
        DateOnly? previous = null;
        foreach (var walkDay in days.Order())
        {
            run = previous == walkDay.AddDays(-1) ? run + 1 : 1;
            best = Math.Max(best, run);
            previous = walkDay;
        }

        return new StreakResult(current, best, walkedToday);
    }
}
