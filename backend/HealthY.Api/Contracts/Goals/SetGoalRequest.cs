using System.ComponentModel.DataAnnotations;
using HealthY.Core.Goals;

namespace HealthY.Api.Contracts.Goals;

public record SetGoalRequest(
    GoalType Type,

    [Range(1, int.MaxValue, ErrorMessage = "Målet skal være mindst 1.")]
    int DailyTarget);
