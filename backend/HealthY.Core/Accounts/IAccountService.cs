namespace HealthY.Core.Accounts;

public interface IAccountService
{
    Task<UserSettings?> GetSettingsAsync(string userId);

    Task SaveSettingsAsync(string userId, UserSettings settings);

    Task DeleteAccountAsync(string userId);
}
