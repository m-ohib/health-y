using HealthY.Core.Common;

namespace HealthY.Infrastructure.Time;

/// <summary>
/// Den rigtige IClock. Giver dansk dato, selvom serveren i Azure kører i UTC.
/// </summary>
public class DanishClock(TimeProvider time) : IClock
{
    public DateTime UtcNow => time.GetUtcNow().UtcDateTime;

    public DateOnly Today
    {
        get
        {
            // TODO: Find tidszonen med TimeZoneInfo.FindSystemTimeZoneById("Europe/Copenhagen"),
            //       konvertér UtcNow med TimeZoneInfo.ConvertTimeFromUtc, og returnér DateOnly.FromDateTime(...).
            // TIP: "Europe/Copenhagen" virker på både Windows (.NET 6+) og Linux i Azure.
            // ÅBENT SPØRGSMÅL: Er dansk tid det rigtige valg? (Forslaget er ja.)
            throw new NotImplementedException();
        }
    }
}
