using HealthY.Core.Streaks;

namespace HealthY.Tests.Streaks;

/// <summary>
/// US 9. Start her: StreakService er ren logik og kræver ingen fakes.
/// </summary>
// TIP: Fjern Skip = "TODO", når du skriver testen. Skippede tests vises gule i Test Explorer, så du kan se, hvad der mangler.
// TIP: Navngivning: Metode_Situation_ForventetResultat. Én ting testes per test.
public class StreakServiceTests
{
    [Fact(Skip = "TODO")]
    public void Calculate_NoWalks_ReturnsZero()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void Calculate_WalkToday_ReturnsOne()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void Calculate_TodayYesterdayAndDayBefore_ReturnsThree()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void Calculate_OnlyYesterday_KeepsStreakAtOne()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void Calculate_GapOfOneDay_StartsOver()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void Calculate_TwoWalksSameDay_CountsAsOneDay()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void Calculate_OldLongerStreak_IsBest()
    {
        // Arrange
        // Act
        // Assert
    }
}
