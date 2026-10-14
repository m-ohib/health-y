namespace HealthY.Core.Goals;

public interface IGoalRepository
{
    Task<Goal?> GetByUserAsync(string userId);

    /// <summary>Opretter målet, hvis brugeren ikke har et. Ellers opdateres det.</summary>
    Task SaveAsync(Goal goal);
}
