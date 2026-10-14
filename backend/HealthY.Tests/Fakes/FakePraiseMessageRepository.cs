using HealthY.Core.Praise;

namespace HealthY.Tests.Fakes;

public class FakePraiseMessageRepository : IPraiseMessageRepository
{
    public List<PraiseMessage> Messages { get; } = [];

    public Task<IReadOnlyList<PraiseMessage>> GetByCategoryAsync(PraiseCategory category)
    {
        // TODO: Filtrér Messages på category.
        throw new NotImplementedException();
    }
}
