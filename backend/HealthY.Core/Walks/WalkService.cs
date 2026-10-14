using HealthY.Core.Common;
using HealthY.Core.Goals;
using HealthY.Core.Praise;
using HealthY.Core.Streaks;

namespace HealthY.Core.Walks;

public class WalkService(
    IWalkRepository walks,
    IGoalService goals,
    IStreakService streaks,
    IPraiseService praise,
    IClock clock) : IWalkService
{
    public Task<IReadOnlyList<Walk>> GetWalksAsync(string userId)
    {
        // TODO: Hent brugerens ture fra repository'et (US 4: nyeste først).
        // TIP: Skal sorteringen ligge her eller i repository'et? Vælg ét sted, og skriv en test for det.
        throw new NotImplementedException();
    }

    public Task<RegisteredWalk> RegisterWalkAsync(string userId, WalkInput input)
    {
        // TODO: 1. Validér input med Validate(input).
        // TODO: 2. Hent turene FØR den nye gemmes. Så kan du se, om det er første tur nogensinde,
        //          første tur i dag, og om der har været en pause.
        // TODO: 3. Opret en Walk (husk UserId og CreatedAt = clock.UtcNow), og gem den med walks.AddAsync.
        // TODO: 4. Beregn streak (streaks.Calculate) og dagens status (goals.CalculateDailyStatus) EFTER den nye tur.
        // TODO: 5. Byg en PraiseContext, og hent rosebeskeden med praise.GetPraiseAsync.
        // TODO: 6. Returnér new RegisteredWalk(walk, besked).
        // TIP: "Mål nået" skal kun give ros, hvis målet blev nået MED denne tur (ikke var nået i forvejen).
        // TIP: Gør det til en vane at skrive "async" på metoden, når du begynder at bruge await.
        throw new NotImplementedException();
    }

    public Task<bool> UpdateWalkAsync(string userId, int walkId, WalkInput input)
    {
        // TODO: Validér, hent turen med walks.GetByIdAsync(userId, walkId), og returnér false, hvis den er null.
        //       Ellers opdatér felterne, og gem.
        // TIP (sikkerhed): Returnér false (bliver til 404 i API'et) både når turen ikke findes, og når den
        //                  tilhører en anden. Så kan man ikke gætte sig til, hvilke id'er der findes.
        throw new NotImplementedException();
    }

    public Task<bool> DeleteWalkAsync(string userId, int walkId)
    {
        // TODO: Som UpdateWalkAsync, men slet turen.
        // TIP: Bekræftelsen ("Er du sikker?") fra US 5 hører til i frontenden, ikke her.
        throw new NotImplementedException();
    }

    private void Validate(WalkInput input)
    {
        // TODO: Kast ValidationException med en venlig dansk besked, hvis:
        //       - Minutes er under WalkRules.MinMinutes eller over WalkRules.MaxMinutes
        //       - Steps er negativ
        //       - Note er længere end WalkRules.MaxNoteLength
        //       - Date ligger i fremtiden (efter clock.Today)
        // TIP: Test grænserne: 0, 1, 600 og 601 minutter, og 500 og 501 tegn i noten.
        throw new NotImplementedException();
    }
}
