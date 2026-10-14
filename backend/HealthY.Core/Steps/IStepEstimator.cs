namespace HealthY.Core.Steps;

public interface IStepEstimator
{
    /// <summary>Skønner antal skridt ud fra minutter (US 13). Vises altid med "ca." i frontenden.</summary>
    int Estimate(int minutes);
}
