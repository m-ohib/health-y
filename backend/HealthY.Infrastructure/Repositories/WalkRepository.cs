using HealthY.Core.Walks;
using HealthY.Infrastructure.Data;

namespace HealthY.Infrastructure.Repositories;

/// <summary>
/// EF Core-implementeringen af IWalkRepository. Kun databasekode her, ingen forretningslogik.
/// </summary>
public class WalkRepository(HealthYDbContext db) : IWalkRepository
{
    public Task<IReadOnlyList<Walk>> GetByUserAsync(string userId)
    {
        // TODO: db.Walks.Where(w => w.UserId == userId).OrderByDescending(w => w.Date).ThenByDescending(w => w.CreatedAt).ToListAsync()
        // TIP: Brug AsNoTracking(), når du kun læser. Det er hurtigere.
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Walk>> GetByUserInPeriodAsync(string userId, DateOnly from, DateOnly to)
    {
        // TODO: Som ovenfor, men også w.Date >= from && w.Date <= to.
        throw new NotImplementedException();
    }

    public Task<Walk?> GetByIdAsync(string userId, int walkId)
    {
        // TODO: db.Walks.FirstOrDefaultAsync(w => w.Id == walkId && w.UserId == userId)
        // TIP (sikkerhed): Det er "&& w.UserId == userId", der forhindrer at man ser andres ture. Glem den aldrig.
        throw new NotImplementedException();
    }

    public Task AddAsync(Walk walk)
    {
        // TODO: db.Walks.Add(walk); await db.SaveChangesAsync();
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Walk walk)
    {
        // TODO: await db.SaveChangesAsync(); (turen er allerede "tracked", fordi den blev hentet med GetByIdAsync)
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Walk walk)
    {
        // TODO: db.Walks.Remove(walk); await db.SaveChangesAsync();
        throw new NotImplementedException();
    }
}
