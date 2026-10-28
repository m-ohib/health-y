namespace HealthY.Core.Steps;

public class StepEstimator : IStepEstimator
{
    public const int StepsPerMinute = 90;

    public int Estimate(int minutes)
    {
        return (int)(minutes * StepsPerMinute);
    }
}
