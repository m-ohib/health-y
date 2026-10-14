namespace HealthY.Core.Accounts;

public interface IAccountRepository
{
    Task<UserSettings?> GetSettingsAsync(string userId);

    Task SaveSettingsAsync(string userId, UserSettings settings);

    /// <summary>Sletter brugeren og ALLE data: ture, noter og mål (GDPR).</summary>
    Task DeleteUserAndAllDataAsync(string userId);
}
