namespace HealthY.Core.Summary;

/// <summary>Én søjle i ugegrafen (US 8).</summary>
public record DaySummary(DateOnly Date, int Minutes, int Steps);
