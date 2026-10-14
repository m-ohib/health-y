using HealthY.Core.Goals;
using HealthY.Core.Streaks;

namespace HealthY.Core.Summary;

/// <summary>Alt, forsiden skal bruge, i ét kald: GET /api/summary/week.</summary>
/// <param name="Days">Præcis 7 dage, ældste først. Dage uden tur har 0.</param>
public record WeekSummary(IReadOnlyList<DaySummary> Days, DailyStatus Today, StreakResult Streak);
