namespace HealthY.Core.Goals;

/// <summary>
/// Brugerens daglige mål (US 6). Én per bruger.
/// </summary>
public class Goal
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public GoalType Type { get; set; }

    public int DailyTarget { get; set; }

    public DateTime UpdatedAt { get; set; }
}
