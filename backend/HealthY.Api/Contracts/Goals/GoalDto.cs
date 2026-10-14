using HealthY.Core.Goals;

namespace HealthY.Api.Contracts.Goals;

public record GoalDto(GoalType Type, int DailyTarget);
