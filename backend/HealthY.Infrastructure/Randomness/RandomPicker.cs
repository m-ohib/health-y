namespace HealthY.Core.Common;

public class RandomPicker : IRandomPicker
{
    public T Pick<T>(IReadOnlyList<T> items)
    {
        // TODO: Returnér et tilfældigt element fra listen.
        // TIP: Random.Shared.Next(items.Count) giver et tilfældigt index.
        // TIP: Kast en ArgumentException, hvis listen er tom.
        throw new NotImplementedException();
    }
}
