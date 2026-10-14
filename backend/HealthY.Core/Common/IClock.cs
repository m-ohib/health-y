namespace HealthY.Core.Common;

/// <summary>
/// Giver "nu" og "i dag" til services, så de aldrig kalder DateTime.Now direkte.
/// </summary>
// TIP: Fordi services får tiden herfra, kan en test sætte "i dag" til en fast dato med en FakeClock.
// TIP: "I dag" skal være dansk dato (Europe/Copenhagen), ikke UTC. Ellers havner en tur kl. 00:30 på gårsdagen.
public interface IClock
{
    DateTime UtcNow { get; }

    DateOnly Today { get; }
}
