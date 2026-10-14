namespace HealthY.Core.Streaks;

/// <summary>
/// Beregner kun streak, intet andet (ét ansvar). Gemmer intet: streak udregnes altid ud fra turene.
/// </summary>
public class StreakService : IStreakService
{
    public StreakResult Calculate(IEnumerable<DateOnly> walkDates, DateOnly today)
    {
        // TODO: 1. Fjern dubletter: flere ture samme dag tæller som én dag (Distinct()).
        // TODO: 2. Current: start i dag. Er der ingen tur i dag, så start i går (streaken er ikke tabt endnu,
        //          for dagen er jo ikke slut). Tæl dage bagud, så længe der er en tur.
        // TODO: 3. Best: find den længste række af dage i træk i hele historikken.
        // TODO: 4. WalkedToday: om today er blandt datoerne.
        // TIP: today.AddDays(-1) giver i går. DateOnly kan sammenlignes direkte med == og <.
        // TIP: Tests du bør skrive: ingen ture = 0, tur i dag = 1, i dag + i går + i forgårs = 3,
        //      kun i går = 1 (ikke 0!), et hul på én dag starter forfra, to ture samme dag = 1.
        // ÅBENT SPØRGSMÅL: "Bedste streak gemmes" (US 9). Her beregnes den i stedet. Det virker, så længe
        //                  brugeren ikke sletter gamle ture. Aftal, om det er godt nok.
        throw new NotImplementedException();
    }
}
