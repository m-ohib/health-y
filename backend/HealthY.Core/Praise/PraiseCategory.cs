namespace HealthY.Core.Praise;

/// <summary>
/// Situationerne fra tabellen "Rosebeskeder" i spec'en. Tallene ER prioriteten: den første, der passer, vinder.
/// </summary>
public enum PraiseCategory
{
    FirstWalkEver = 1,
    StreakMilestone = 2,
    BackAfterBreak = 3,
    GoalReached = 4,
    LongWalk = 5,
    MediumWalk = 6,
    ShortWalk = 7,
}
