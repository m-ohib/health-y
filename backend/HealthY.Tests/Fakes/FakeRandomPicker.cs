using HealthY.Core.Common;

namespace HealthY.Tests.Fakes;

/// <summary>
/// "Tilfældighed", der altid vælger det første element, så tests giver samme resultat hver gang.
/// </summary>
public class FakeRandomPicker : IRandomPicker
{
    public T Pick<T>(IReadOnlyList<T> items)
    {
        // TODO: return items[0];
        throw new NotImplementedException();
    }
}
