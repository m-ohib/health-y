using HealthY.Core.Goals;

namespace HealthY.Api.Contracts.Summary;

public record DayDto(DateOnly Date, int Minutes, int Steps);

/// <param name="IsEstimated">True, hvis "Achieved" er skønnede skridt. Frontenden skriver så "ca.".</param>
public record TodayDto(GoalType Type, int Achieved, int? Target, bool IsReached, bool IsEstimated);

public record StreakDto(int Current, int Best, bool WalkedToday);

public record WeekSummaryDto(IReadOnlyList<DayDto> Days, TodayDto Today, StreakDto Streak);
