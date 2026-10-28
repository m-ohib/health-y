using HealthY.Core.Steps;

namespace HealthY.Tests.Steps;

public class StepEstimatorTests
{
    [Fact]
    public void Estimate_TenMinutes_Returns900()
    {
        var estimator = new StepEstimator();
        var result = estimator.Estimate(10);
        Assert.Equal(900, result);
    }

    [Fact]
    public void Estimate_ZeroMinutes_ReturnsZero()
    {
        var estimator = new StepEstimator();
        var result = estimator.Estimate(0);
        Assert.Equal(0, result);
    }
}
