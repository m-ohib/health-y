using HealthY.Core.Praise;
using HealthY.Infrastructure.Data;

namespace HealthY.Infrastructure.Repositories;

public class PraiseMessageRepository(HealthYDbContext db) : IPraiseMessageRepository
{
    public Task<IReadOnlyList<PraiseMessage>> GetByCategoryAsync(PraiseCategory category)
    {
        // TODO: db.PraiseMessages.AsNoTracking().Where(p => p.Category == category).ToListAsync()
        throw new NotImplementedException();
    }
}
