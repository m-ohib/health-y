namespace HealthY.Core.Goals;

/// <summary>
/// Dagens fremskridt mod målet, fx "22 af 30 minutter" (US 7).
/// </summary>
/// <param name="Achieved">Det, der er gået i dag (minutter eller skridt).</param>
/// <param name="Target">Målet. Null, hvis brugeren ikke har sat et mål.</param>
/// <param name="IsEstimated">True, hvis skridt er skønnet ud fra minutter (vises med "ca.").</param>
public record DailyStatus(GoalType Type, int Achieved, int? Target, bool IsReached, bool IsEstimated);
