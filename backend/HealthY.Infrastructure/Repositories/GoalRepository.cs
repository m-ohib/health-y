using HealthY.Core.Goals;
using HealthY.Infrastructure.Data;

namespace HealthY.Infrastructure.Repositories;

public class GoalRepository(HealthYDbContext db) : IGoalRepository
{
    public Task<Goal?> GetByUserAsync(string userId)
    {
        // TODO: db.Goals.FirstOrDefaultAsync(g => g.UserId == userId)
        throw new NotImplementedException();
    }

    public Task SaveAsync(Goal goal)
    {
        // TODO: Hvis goal.Id == 0 er det nyt: db.Goals.Add(goal). Gem derefter med SaveChangesAsync.
        throw new NotImplementedException();
    }
}
