namespace HealthY.Core.Praise;

public interface IPraiseMessageRepository
{
    Task<IReadOnlyList<PraiseMessage>> GetByCategoryAsync(PraiseCategory category);
}
