namespace HealthY.Core.Praise;

/// <summary>
/// Alt, PraiseService skal vide for at vælge en besked. WalkService bygger den.
/// </summary>
/// <param name="LastMessageId">Id på den sidst viste besked, så samme besked ikke vises to gange i træk.</param>
public record PraiseContext(
    bool IsFirstWalkEver,
    int CurrentStreak,
    bool IsFirstWalkToday,
    bool IsFirstWalkAfterBreak,
    bool GoalReachedWithThisWalk,
    int Minutes,
    int? LastMessageId);
