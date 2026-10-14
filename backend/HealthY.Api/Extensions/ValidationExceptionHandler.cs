using HealthY.Core.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HealthY.Api.Extensions;

/// <summary>
/// Oversætter ValidationException fra Core til 400 Bad Request med den danske besked.
/// Så skal controllerne ikke have try/catch.
/// </summary>
public class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validation)
        {
            return false;
        }

        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(
            new ProblemDetails { Status = StatusCodes.Status400BadRequest, Detail = validation.Message },
            cancellationToken);
        return true;
    }
}
