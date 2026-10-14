using HealthY.Api.Contracts.Walks;
using HealthY.Api.Extensions;
using HealthY.Core.Steps;
using HealthY.Core.Walks;
using Microsoft.AspNetCore.Mvc;

namespace HealthY.Api.Controllers;

/// <summary>
/// US 3, 4, 5, 12, 13 og 14. Kræver login (fallback-policy i Program.cs).
/// </summary>
[ApiController]
[Route("api/walks")]
public class WalksController(IWalkService walks, IStepEstimator stepEstimator) : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<IEnumerable<WalkDto>>> GetAll()
    {
        // TODO: var list = await walks.GetWalksAsync(User.GetUserId());
        //       return Ok(list.Select(w => w.ToDto(stepEstimator)));
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<ActionResult<RegisteredWalkResponse>> Create(SaveWalkRequest request)
    {
        // TODO: var result = await walks.RegisterWalkAsync(User.GetUserId(), request.ToInput());
        //       return Ok(new RegisteredWalkResponse(result.Walk.ToDto(stepEstimator), result.Praise));
        // TIP: Ønsker du at være helt REST-korrekt, kan du returnere 201 Created i stedet for 200 OK.
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}")]
    public Task<IActionResult> Update(int id, SaveWalkRequest request)
    {
        // TODO: var ok = await walks.UpdateWalkAsync(User.GetUserId(), id, request.ToInput());
        //       return ok ? NoContent() : NotFound();
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public Task<IActionResult> Delete(int id)
    {
        // TODO: Som Update, men med walks.DeleteWalkAsync.
        throw new NotImplementedException();
    }
}
