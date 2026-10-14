using HealthY.Core.Common;
using HealthY.Core.Walks;
using HealthY.Tests.Builders;
using HealthY.Tests.Fakes;

namespace HealthY.Tests.Walks;

/// <summary>
/// US 3, 4, 5 og 14 + adgangskontrol (bruger A må ikke røre bruger B's ture).
/// </summary>
// TIP: Fjern Skip = "TODO", når du skriver testen. Skippede tests vises gule i Test Explorer, så du kan se, hvad der mangler.
// TIP: Navngivning: Metode_Situation_ForventetResultat. Én ting testes per test.
public class WalkServiceTests
{
    [Fact(Skip = "TODO")]
    public void RegisterWalk_ZeroMinutes_ThrowsValidationException()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void RegisterWalk_601Minutes_ThrowsValidationException()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void RegisterWalk_600Minutes_IsSaved()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void RegisterWalk_NoteOf501Chars_ThrowsValidationException()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void RegisterWalk_DateInFuture_ThrowsValidationException()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void RegisterWalk_FirstWalkEver_ReturnsPraise()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void UpdateWalk_OtherUsersWalk_ReturnsFalse()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void DeleteWalk_OtherUsersWalk_ReturnsFalse()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact(Skip = "TODO")]
    public void GetWalks_ReturnsNewestFirst()
    {
        // Arrange
        // Act
        // Assert
    }
}
