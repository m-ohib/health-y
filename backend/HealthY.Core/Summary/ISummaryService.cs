namespace HealthY.Core.Summary;

public interface ISummaryService
{
    Task<WeekSummary> GetWeekAsync(string userId);
}
