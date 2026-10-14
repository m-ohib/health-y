using HealthY.Core.Common;

namespace HealthY.Core.Accounts;

public class AccountService(IAccountRepository accounts, IClock clock) : IAccountService
{
    public Task<UserSettings?> GetSettingsAsync(string userId)
    {
        // TODO: Hent indstillinger fra repository'et.
        throw new NotImplementedException();
    }

    public Task SaveSettingsAsync(string userId, UserSettings settings)
    {
        // TODO: Validér fødselsår (fx mellem 1900 og clock.Today.Year), og gem.
        throw new NotImplementedException();
    }

    public Task DeleteAccountAsync(string userId)
    {
        // TODO: Kald accounts.DeleteUserAndAllDataAsync.
        // TIP: Skriv en test (gerne en integrationstest), der viser, at ture og mål er væk bagefter. Det er et GDPR-krav.
        throw new NotImplementedException();
    }
}
