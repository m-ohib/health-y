using HealthY.Core.Steps;
using HealthY.Core.Walks;

namespace HealthY.Api.Contracts.Walks;

/// <summary>
/// Omsætning mellem entitet og DTO samlet ét sted.
/// </summary>
public static class WalkMappings
{
    public static WalkDto ToDto(this Walk walk, IStepEstimator stepEstimator)
    {
        // TODO: Returnér new WalkDto(...). EstimatedSteps = stepEstimator.Estimate(walk.Minutes), men kun når walk.Steps er null.
        throw new NotImplementedException();
    }

    public static WalkInput ToInput(this SaveWalkRequest request) =>
        new(request.Date, request.Minutes, request.Steps, request.Note);
}
