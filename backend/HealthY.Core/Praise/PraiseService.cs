using HealthY.Core.Common;

namespace HealthY.Core.Praise;

/// <summary>
/// Vælger kun rosebesked, intet andet (ét ansvar).
/// </summary>
public class PraiseService(IPraiseMessageRepository messages, IRandomPicker random) : IPraiseService
{
    /// <summary>Streak-længder, der giver en særlig besked.</summary>
    public static readonly int[] StreakMilestones = [3, 7, 14, 30];

    public PraiseCategory SelectCategory(PraiseContext context)
    {
        // TODO: Gå situationerne igennem i rækkefølge, og returnér den første, der passer:
        //       1. IsFirstWalkEver
        //       2. Streak-milepæl: CurrentStreak er i StreakMilestones OG IsFirstWalkToday
        //          (ellers får man milepæls-ros igen for tur nr. 2 samme dag)
        //       3. IsFirstWalkAfterBreak
        //       4. GoalReachedWithThisWalk
        //       5. Minutes >= 30 -> LongWalk
        //       6. Minutes >= 15 -> MediumWalk
        //       7. ellers -> ShortWalk
        // TIP: Grænsetests: 14 = Kort, 15 = Mellem, 29 = Mellem, 30 = Lang.
        throw new NotImplementedException();
    }

    public Task<string> GetPraiseAsync(PraiseContext context)
    {
        // TODO: 1. Find kategori med SelectCategory.
        // TODO: 2. Hent beskeder i kategorien med messages.GetByCategoryAsync.
        // TODO: 3. Fjern den med LastMessageId (men kun hvis der så stadig er mindst én tilbage).
        // TODO: 4. Vælg én med random.Pick, og erstat "{dage}" med context.CurrentStreak.
        // TIP: Streak-beskederne er skrevet til hver sin milepæl (3, 7, 14, 30 dage). Overvej at matche
        //      en bestemt besked til en bestemt milepæl i stedet for at vælge tilfældigt.
        // ÅBENT SPØRGSMÅL: LastMessageId skal gemmes et sted (fx på brugeren). Det findes ikke i datamodellen endnu.
        throw new NotImplementedException();
    }
}
