using HealthY.Core.Streaks;

namespace HealthY.Tests.Streaks;

public class StreakServiceTests
{
    private static readonly DateOnly Today = new DateOnly(2026, 10, 27);

    [Fact]
    public void Calculate_NoWalks_ReturnsZero()
    {
        // Arrange
        var service = new StreakService();
        var walkDates = new DateOnly[0];

        // Act
        var result = service.Calculate(walkDates, Today);

        // Assert
        Assert.Equal(0, result.Current);
        Assert.Equal(0, result.Best);
        Assert.False(result.WalkedToday);
    }

    [Fact]
    public void Calculate_WalkToday_ReturnsOne()
    {
        // Arrange
        var service = new StreakService();
        var walkDates = new[] { Today };

        // Act
        var result = service.Calculate(walkDates, Today);

        // Assert
        Assert.Equal(1, result.Current);
        Assert.True(result.WalkedToday);
    }

    [Fact]
    public void Calculate_TodayYesterdayAndDayBefore_ReturnsThree()
    {
        // Arrange
        var service = new StreakService();
        var walkDates = new[]
        {
            new DateOnly(2026, 10, 25),
            new DateOnly(2026, 10, 26),
            Today,
        };

        // Act
        var result = service.Calculate(walkDates, Today);

        // Assert
        Assert.Equal(3, result.Current);
    }

    [Fact]
    public void Calculate_OnlyYesterday_KeepsStreakAtOne()
    {
        // Arrange
        var service = new StreakService();
        var walkDates = new[] { new DateOnly(2026, 10, 26) };

        // Act
        var result = service.Calculate(walkDates, Today);

        // Assert
        Assert.Equal(1, result.Current);
        Assert.False(result.WalkedToday);
    }

    [Fact]
    public void Calculate_GapOfOneDay_StartsOver()
    {
        // Arrange
        var service = new StreakService();
        var walkDates = new[]
        {
            new DateOnly(2026, 10, 24),
            new DateOnly(2026, 10, 26),
            Today,
        };

        // Act
        var result = service.Calculate(walkDates, Today);

        // Assert
        Assert.Equal(2, result.Current);
    }

    [Fact]
    public void Calculate_TwoWalksSameDay_CountsAsOneDay()
    {
        // Arrange
        var service = new StreakService();
        var walkDates = new[] { Today, Today };

        // Act
        var result = service.Calculate(walkDates, Today);

        // Assert
        Assert.Equal(1, result.Current);
    }

    [Fact]
    public void Calculate_OldLongerStreak_IsBest()
    {
        // Arrange
        var service = new StreakService();
        var walkDates = new[]
        {
            new DateOnly(2026, 10, 1),
            new DateOnly(2026, 10, 2),
            new DateOnly(2026, 10, 3),
            new DateOnly(2026, 10, 4),
            new DateOnly(2026, 10, 5),
            new DateOnly(2026, 10, 26),
            Today,
        };

        // Act
        var result = service.Calculate(walkDates, Today);

        // Assert
        Assert.Equal(2, result.Current);
        Assert.Equal(5, result.Best);
    }
}
