using HealthY.Api.Contracts.Summary;
using HealthY.Api.Extensions;
using HealthY.Core.Summary;
using Microsoft.AspNetCore.Mvc;

namespace HealthY.Api.Controllers;

/// <summary>US 7, 8 og 9: forsidens tal i ét kald.</summary>
[ApiController]
[Route("api/summary")]
public class SummaryController(ISummaryService summary) : ControllerBase
{
    [HttpGet("week")]
    public Task<ActionResult<WeekSummaryDto>> GetWeek()
    {
        // TODO: var week = await summary.GetWeekAsync(User.GetUserId());
        //       Omsæt WeekSummary til WeekSummaryDto (DayDto, TodayDto, StreakDto), og return Ok(dto).
        // TIP: Laver du mange omsætninger, så læg dem i en SummaryMappings-klasse som WalkMappings.
        throw new NotImplementedException();
    }
}
