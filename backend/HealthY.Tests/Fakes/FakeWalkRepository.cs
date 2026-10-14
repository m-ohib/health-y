using HealthY.Core.Walks;

namespace HealthY.Tests.Fakes;

/// <summary>
/// Et repository i hukommelsen. Ingen database: testen lægger selv ture i listen.
/// </summary>
// TIP: Kan en service testes med denne fake, er koblingen lav nok (spec'ens målestok).
public class FakeWalkRepository : IWalkRepository
{
    public List<Walk> Walks { get; } = [];

    public Task<IReadOnlyList<Walk>> GetByUserAsync(string userId)
    {
        // TODO: Filtrér Walks på userId, sortér nyeste først, og returnér med Task.FromResult<IReadOnlyList<Walk>>(...).
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Walk>> GetByUserInPeriodAsync(string userId, DateOnly from, DateOnly to)
    {
        // TODO: Som ovenfor, men også filtreret på dato.
        throw new NotImplementedException();
    }

    public Task<Walk?> GetByIdAsync(string userId, int walkId)
    {
        // TODO: Find turen med både walkId OG userId (ligesom den rigtige).
        throw new NotImplementedException();
    }

    public Task AddAsync(Walk walk)
    {
        // TODO: Giv turen et Id (fx Walks.Count + 1), læg den i listen, og return Task.CompletedTask.
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Walk walk) => Task.CompletedTask;

    public Task DeleteAsync(Walk walk)
    {
        // TODO: Walks.Remove(walk); return Task.CompletedTask;
        throw new NotImplementedException();
    }
}
