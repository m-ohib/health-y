namespace HealthY.Core.Steps;

public class StepEstimator : IStepEstimator
{
    /// <summary>Spec'en siger ca. 80–100 skridt i minuttet. 90 er midten.</summary>
    public const int StepsPerMinute = 90;

    public int Estimate(int minutes)
    {
        // TODO: Returnér minutes * StepsPerMinute.
        // TIP: Hvad skal der ske med 0 eller negative minutter? Skriv en test for det.
        throw new NotImplementedException();
    }
}
