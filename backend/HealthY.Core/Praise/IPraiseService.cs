namespace HealthY.Core.Praise;

public interface IPraiseService
{
    /// <summary>Ren beregning: hvilken situation passer? (Første match i prioriteret rækkefølge.)</summary>
    PraiseCategory SelectCategory(PraiseContext context);

    /// <summary>Vælger kategori, henter beskeder og returnerer én tilfældig tekst.</summary>
    Task<string> GetPraiseAsync(PraiseContext context);
}
