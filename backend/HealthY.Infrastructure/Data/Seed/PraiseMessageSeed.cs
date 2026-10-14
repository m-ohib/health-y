using HealthY.Core.Praise;

namespace HealthY.Infrastructure.Data.Seed;

/// <summary>
/// Rosebeskederne fra spec'en. Nye beskeder: tilføj en linje med et nyt Id, og lav en ny migration.
/// </summary>
public static class PraiseMessageSeed
{
    public static readonly PraiseMessage[] All =
    [
        new PraiseMessage { Id = 1, Category = PraiseCategory.FirstWalkEver, Text = "Din første tur er registreret. Det er det sværeste skridt, og det har du taget." },
        new PraiseMessage { Id = 2, Category = PraiseCategory.FirstWalkEver, Text = "Velkommen i gang. Enhver lang rejse starter med en kort tur." },
        new PraiseMessage { Id = 3, Category = PraiseCategory.StreakMilestone, Text = "{dage} dage i træk. Det er sådan, gode vaner bliver til." },
        new PraiseMessage { Id = 4, Category = PraiseCategory.StreakMilestone, Text = "En hel uge i træk. Det er en rigtig god start." },
        new PraiseMessage { Id = 5, Category = PraiseCategory.StreakMilestone, Text = "To uger i træk. Gåturen er ved at blive en del af din hverdag." },
        new PraiseMessage { Id = 6, Category = PraiseCategory.StreakMilestone, Text = "30 dage i træk. Nu er det en vane." },
        new PraiseMessage { Id = 7, Category = PraiseCategory.BackAfterBreak, Text = "Dejligt at se dig igen. I dag tæller." },
        new PraiseMessage { Id = 8, Category = PraiseCategory.BackAfterBreak, Text = "Velkommen tilbage. Vi starter bare forfra, og det er helt fint." },
        new PraiseMessage { Id = 9, Category = PraiseCategory.BackAfterBreak, Text = "Godt at være i gang igen. Det vigtigste er at komme ud." },
        new PraiseMessage { Id = 10, Category = PraiseCategory.GoalReached, Text = "Dagens mål er nået. Godt gået." },
        new PraiseMessage { Id = 11, Category = PraiseCategory.GoalReached, Text = "Mål nået. Resten af dagen er bonus." },
        new PraiseMessage { Id = 12, Category = PraiseCategory.GoalReached, Text = "Du gjorde, hvad du satte dig for i dag." },
        new PraiseMessage { Id = 13, Category = PraiseCategory.LongWalk, Text = "Sikke en tur. Det kan du være stolt af." },
        new PraiseMessage { Id = 14, Category = PraiseCategory.LongWalk, Text = "Over en halv time. Imponerende." },
        new PraiseMessage { Id = 15, Category = PraiseCategory.LongWalk, Text = "En lang tur i dag. Husk at drikke et glas vand." },
        new PraiseMessage { Id = 16, Category = PraiseCategory.LongWalk, Text = "Flot indsats. Dit hjerte har haft en god dag." },
        new PraiseMessage { Id = 17, Category = PraiseCategory.MediumWalk, Text = "Flot tur. Dine ben siger tak." },
        new PraiseMessage { Id = 18, Category = PraiseCategory.MediumWalk, Text = "Det er en rigtig god gåtur." },
        new PraiseMessage { Id = 19, Category = PraiseCategory.MediumWalk, Text = "Godt gået. Sådan bliver gode vaner til." },
        new PraiseMessage { Id = 20, Category = PraiseCategory.MediumWalk, Text = "Det var en tur, der kunne mærkes. Godt klaret." },
        new PraiseMessage { Id = 21, Category = PraiseCategory.ShortWalk, Text = "Godt gået. Hvert skridt tæller." },
        new PraiseMessage { Id = 22, Category = PraiseCategory.ShortWalk, Text = "En kort tur er stadig en tur. Godt klaret." },
        new PraiseMessage { Id = 23, Category = PraiseCategory.ShortWalk, Text = "Lidt frisk luft gør en forskel for både krop og humør." },
        new PraiseMessage { Id = 24, Category = PraiseCategory.ShortWalk, Text = "Lidt er meget mere end ingenting. Flot." },
    ];
}
