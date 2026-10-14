using HealthY.Core.Goals;

namespace HealthY.Tests.Fakes;

public class FakeGoalRepository : IGoalRepository
{
    public List<Goal> Goals { get; } = [];

    public Task<Goal?> GetByUserAsync(string userId)
    {
        // TODO: Task.FromResult(Goals.FirstOrDefault(g => g.UserId == userId))
        throw new NotImplementedException();
    }

    public Task SaveAsync(Goal goal)
    {
        // TODO: Tilføj til listen, hvis den ikke allerede er der.
        throw new NotImplementedException();
    }
}
