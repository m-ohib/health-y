using HealthY.Core.Walks;

namespace HealthY.Core.Goals;

public interface IGoalService
{
    Task<Goal?> GetGoalAsync(string userId);

    Task<Goal> SetGoalAsync(string userId, GoalType type, int dailyTarget);

    /// <summary>
    /// Ren beregning uden database: hvor langt er brugeren nået i dag?
    /// </summary>
    DailyStatus CalculateDailyStatus(Goal? goal, IEnumerable<Walk> todaysWalks);

    /// <summary>Henter mål og dagens ture og kalder CalculateDailyStatus.</summary>
    Task<DailyStatus> GetDailyStatusAsync(string userId);
}
