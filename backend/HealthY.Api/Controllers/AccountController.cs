using HealthY.Api.Contracts.Account;
using HealthY.Api.Extensions;
using HealthY.Core.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace HealthY.Api.Controllers;

/// <summary>US 10 (indstillinger) og GDPR (slet konto).</summary>
[ApiController]
[Route("api/account")]
public class AccountController(IAccountService accounts) : ControllerBase
{
    // NB: GET/PUT /api/account/settings står ikke i spec'ens endpoint-liste, men US 10 kræver,
    //     at visningen kan skiftes under Indstillinger.
    [HttpGet("settings")]
    public Task<ActionResult<SettingsDto>> GetSettings()
    {
        // TODO: Hent indstillinger for User.GetUserId(), og returnér som SettingsDto.
        throw new NotImplementedException();
    }

    [HttpPut("settings")]
    public Task<IActionResult> SaveSettings(SettingsDto request)
    {
        // TODO: Gem, og return NoContent().
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> Delete()
    {
        // TODO: await accounts.DeleteAccountAsync(User.GetUserId()); return NoContent();
        // TIP: Frontenden skal spørge "Er du sikker?" og logge ud bagefter.
        throw new NotImplementedException();
    }
}
