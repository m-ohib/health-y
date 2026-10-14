namespace HealthY.Core.Walks;

/// <summary>
/// Grænser fra acceptkriterierne (US 3 og 14). Samlet ét sted, så DTO'er og services bruger de samme tal.
/// </summary>
public static class WalkRules
{
    public const int MinMinutes = 1;
    public const int MaxMinutes = 600;
    public const int MaxNoteLength = 500;

    /// <summary>Hurtigknapperne i Enkel visning: Kort, Mellem, Lang.</summary>
    public const int ShortWalkMinutes = 10;
    public const int MediumWalkMinutes = 20;
    public const int LongWalkMinutes = 30;
}
