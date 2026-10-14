using HealthY.Core.Common;
using HealthY.Core.Steps;
using HealthY.Core.Walks;

namespace HealthY.Core.Goals;

public class GoalService(
    IGoalRepository goals,
    IWalkRepository walks,
    IStepEstimator stepEstimator,
    IClock clock) : IGoalService
{
    public Task<Goal?> GetGoalAsync(string userId)
    {
        // TODO: Hent målet fra repository'et.
        throw new NotImplementedException();
    }

    public Task<Goal> SetGoalAsync(string userId, GoalType type, int dailyTarget)
    {
        // TODO: Kast ValidationException, hvis dailyTarget er 0 eller negativ.
        // TODO: Hent eksisterende mål (eller lav et nyt), sæt Type, DailyTarget og UpdatedAt = clock.UtcNow, og gem.
        // TIP: Overvej en øvre grænse (fx 600 minutter eller 50.000 skridt), så en tastefejl ikke giver et umuligt mål.
        throw new NotImplementedException();
    }

    public DailyStatus CalculateDailyStatus(Goal? goal, IEnumerable<Walk> todaysWalks)
    {
        // TODO: Minutter: læg Minutes sammen for alle dagens ture.
        // TODO: Skridt: læg Steps sammen. Ture uden Steps får et skøn fra stepEstimator.Estimate(minutes),
        //       og så skal IsEstimated være true (US 13).
        // TODO: IsReached = Achieved >= DailyTarget (false, hvis der ikke er noget mål).
        // TIP: Denne metode er "ren" (ingen database, ingen tid), så den er nem at teste. Start gerne her.
        // ÅBENT SPØRGSMÅL: Skal skønnede skridt tælle med mod et skridt-mål? Aftal det, før du koder det.
        throw new NotImplementedException();
    }

    public Task<DailyStatus> GetDailyStatusAsync(string userId)
    {
        // TODO: Hent mål og dagens ture (walks.GetByUserInPeriodAsync(userId, clock.Today, clock.Today)),
        //       og returnér CalculateDailyStatus(goal, ture).
        throw new NotImplementedException();
    }
}
