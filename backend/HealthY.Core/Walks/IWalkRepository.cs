namespace HealthY.Core.Walks;

/// <summary>
/// Adgang til gemte gåture. Core kender kun dette interface. EF Core-implementeringen ligger i Infrastructure.
/// </summary>
// TIP (sikkerhed): Alle metoder tager userId. Så kan en bruger aldrig få fat i andres ture,
//                  heller ikke hvis nogen gætter et walkId.
public interface IWalkRepository
{
    /// <summary>Alle brugerens ture, nyeste først.</summary>
    Task<IReadOnlyList<Walk>> GetByUserAsync(string userId);

    /// <summary>Brugerens ture fra og med <paramref name="from"/> til og med <paramref name="to"/>.</summary>
    Task<IReadOnlyList<Walk>> GetByUserInPeriodAsync(string userId, DateOnly from, DateOnly to);

    /// <summary>Én tur, men kun hvis den tilhører brugeren. Ellers null.</summary>
    Task<Walk?> GetByIdAsync(string userId, int walkId);

    Task AddAsync(Walk walk);

    Task UpdateAsync(Walk walk);

    Task DeleteAsync(Walk walk);
}
