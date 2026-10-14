using HealthY.Core.Common;
using HealthY.Core.Goals;
using HealthY.Core.Streaks;
using HealthY.Core.Walks;

namespace HealthY.Core.Summary;

/// <summary>
/// Samler data til forsiden. Selve beregningerne overlades til GoalService og StreakService.
/// </summary>
public class SummaryService(
    IWalkRepository walks,
    IGoalService goals,
    IStreakService streaks,
    IClock clock) : ISummaryService
{
    public Task<WeekSummary> GetWeekAsync(string userId)
    {
        // TODO: 1. Hent ALLE brugerens ture (streak skal bruge hele historikken) og målet.
        // TODO: 2. Byg 7 DaySummary'er fra clock.Today.AddDays(-6) til clock.Today.
        //          Dage uden tur skal med som 0, ellers mangler der søjler i grafen.
        // TODO: 3. Today = goals.CalculateDailyStatus(mål, dagens ture).
        // TODO: 4. Streak = streaks.Calculate(alle datoer, clock.Today).
        // TIP: Hent turene én gang, og genbrug listen i stedet for at spørge databasen tre gange.
        throw new NotImplementedException();
    }
}
