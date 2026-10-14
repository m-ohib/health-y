namespace HealthY.Core.Common;

/// <summary>
/// Vælger et tilfældigt element. Ligger bag et interface, så tests kan styre "tilfældigheden".
/// </summary>
public interface IRandomPicker
{
    T Pick<T>(IReadOnlyList<T> items);
}
