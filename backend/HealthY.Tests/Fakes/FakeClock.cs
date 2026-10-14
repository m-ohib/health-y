using HealthY.Core.Common;

namespace HealthY.Tests.Fakes;

/// <summary>
/// Et ur, testen selv styrer: new FakeClock(new DateOnly(2026, 10, 9)).
/// </summary>
public class FakeClock(DateOnly today) : IClock
{
    public DateOnly Today { get; set; } = today;

    public DateTime UtcNow => Today.ToDateTime(new TimeOnly(12, 0), DateTimeKind.Utc);
}
