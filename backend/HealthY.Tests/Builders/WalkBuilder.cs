using HealthY.Core.Walks;

namespace HealthY.Tests.Builders;

/// <summary>
/// Gør tests læsbare: new WalkBuilder().On(idag).WithMinutes(20).Build()
/// </summary>
public class WalkBuilder
{
    private readonly Walk _walk = new()
    {
        UserId = "user-1",
        Date = new DateOnly(2026, 10, 9),
        Minutes = 20,
    };

    public WalkBuilder ForUser(string userId)
    {
        _walk.UserId = userId;
        return this;
    }

    public WalkBuilder On(DateOnly date)
    {
        _walk.Date = date;
        return this;
    }

    public WalkBuilder WithMinutes(int minutes)
    {
        _walk.Minutes = minutes;
        return this;
    }

    public WalkBuilder WithSteps(int? steps)
    {
        _walk.Steps = steps;
        return this;
    }

    public Walk Build() => _walk;
}
