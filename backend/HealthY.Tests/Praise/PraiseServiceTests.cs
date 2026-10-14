using HealthY.Core.Praise;
using HealthY.Tests.Fakes;

namespace HealthY.Tests.Praise;

/// <summary>
/// US 12. Brug FakePraiseMessageRepository og FakeRandomPicker.
/// </summary>
// TIP: Fjern Skip = "TODO", når du skriver testen. Skippede tests vises gule i Test Explorer, så du kan se, hvad der mangler.
// TIP: Navngivning: Metode_Situation_ForventetResultat. Én ting testes per test.
public class PraiseServiceTests
{
    [Fact(Skip = "TODO")]
    public void SelectCategory_FirstWalkEver_WinsOverEverything()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SelectCategory_StreakMilestoneOnFirstWalkToday_ReturnsStreakMilestone()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SelectCategory_StreakMilestoneOnSecondWalkToday_IsNotMilestone()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SelectCategory_GoalReached_WinsOverWalkLength()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SelectCategory_14Minutes_ReturnsShortWalk()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SelectCategory_15Minutes_ReturnsMediumWalk()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SelectCategory_29Minutes_ReturnsMediumWalk()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SelectCategory_30Minutes_ReturnsLongWalk()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void GetPraise_LastMessageShown_IsNotRepeated()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void GetPraise_StreakText_ReplacesDage()
    {
        // Arrange
        // Act
        // Assert
    }
}
