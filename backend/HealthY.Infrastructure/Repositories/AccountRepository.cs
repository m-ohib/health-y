using HealthY.Core.Accounts;
using HealthY.Infrastructure.Data;
using HealthY.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace HealthY.Infrastructure.Repositories;

public class AccountRepository(UserManager<ApplicationUser> users, HealthYDbContext db) : IAccountRepository
{
    public Task<UserSettings?> GetSettingsAsync(string userId)
    {
        // TODO: Find brugeren med users.FindByIdAsync(userId), og returnér new UserSettings(user.BirthYear, user.ViewMode).
        throw new NotImplementedException();
    }

    public Task SaveSettingsAsync(string userId, UserSettings settings)
    {
        // TODO: Find brugeren, sæt BirthYear og ViewMode, og gem med users.UpdateAsync(user).
        throw new NotImplementedException();
    }

    public Task DeleteUserAndAllDataAsync(string userId)
    {
        // TODO: Find brugeren, og slet med users.DeleteAsync(user).
        // TIP: Har du sat cascade delete op i WalkConfiguration og GoalConfiguration, forsvinder ture og mål automatisk.
        //      Ellers skal du selv slette dem via db først.
        throw new NotImplementedException();
    }
}
