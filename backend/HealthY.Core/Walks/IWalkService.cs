namespace HealthY.Core.Walks;

public interface IWalkService
{
    Task<IReadOnlyList<Walk>> GetWalksAsync(string userId);

    /// <summary>Gemmer turen og finder den rosebesked, der skal vises (US 3 og 12).</summary>
    Task<RegisteredWalk> RegisterWalkAsync(string userId, WalkInput input);

    /// <summary>Returnerer false, hvis turen ikke findes eller tilhører en anden.</summary>
    Task<bool> UpdateWalkAsync(string userId, int walkId, WalkInput input);

    /// <summary>Returnerer false, hvis turen ikke findes eller tilhører en anden.</summary>
    Task<bool> DeleteWalkAsync(string userId, int walkId);
}
