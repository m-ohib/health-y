using HealthY.Api.Contracts.Goals;
using HealthY.Api.Extensions;
using HealthY.Core.Goals;
using Microsoft.AspNetCore.Mvc;

namespace HealthY.Api.Controllers;

/// <summary>US 6.</summary>
[ApiController]
[Route("api/goal")]
public class GoalController(IGoalService goals) : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<GoalDto>> Get()
    {
        // TODO: Hent målet. Har brugeren intet mål: return NoContent() (frontenden viser så "Sæt dit mål").
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task<ActionResult<GoalDto>> Set(SetGoalRequest request)
    {
        // TODO: var goal = await goals.SetGoalAsync(User.GetUserId(), request.Type, request.DailyTarget);
        //       return Ok(new GoalDto(goal.Type, goal.DailyTarget));
        throw new NotImplementedException();
    }
}
