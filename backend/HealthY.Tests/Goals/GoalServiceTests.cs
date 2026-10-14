using HealthY.Core.Goals;
using HealthY.Tests.Builders;
using HealthY.Tests.Fakes;

namespace HealthY.Tests.Goals;

/// <summary>
/// US 6, 7 og 13.
/// </summary>
// TIP: Fjern Skip = "TODO", når du skriver testen. Skippede tests vises gule i Test Explorer, så du kan se, hvad der mangler.
// TIP: Navngivning: Metode_Situation_ForventetResultat. Én ting testes per test.
public class GoalServiceTests
{
    [Fact(Skip = "TODO")]
    public void CalculateDailyStatus_TwoWalks_SumsMinutes()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void CalculateDailyStatus_StepsGoal_SumsSteps()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void CalculateDailyStatus_WalkWithoutSteps_IsEstimated()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void CalculateDailyStatus_ExactlyAtTarget_IsReached()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void CalculateDailyStatus_NoGoal_IsNotReached()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void SetGoal_ZeroTarget_ThrowsValidationException()
    {
        // Arrange
        // Act
        // Assert
    }
}
