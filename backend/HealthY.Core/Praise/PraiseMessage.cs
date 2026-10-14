namespace HealthY.Core.Praise;

/// <summary>
/// En rosebesked fra databasen, så nye beskeder kan tilføjes uden at ændre koden.
/// </summary>
public class PraiseMessage
{
    public int Id { get; set; }

    public PraiseCategory Category { get; set; }

    /// <summary>Kan indeholde {dage}, som erstattes med streakens længde.</summary>
    public string Text { get; set; } = string.Empty;
}
