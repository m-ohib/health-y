# US 9 – Streak

> Som bruger vil jeg se min streak.
> Dage i træk med mindst én gåtur uanset længde (målet behøver ikke være nået). Efter en dag uden tur: opmuntrende besked, ikke "streak tabt". Bedste streak vises.

**Filer**
- `backend/HealthY.Core/streaks/IStreakService.cs` – interfacet
- `backend/HealthY.Core/streaks/StreakResult.cs` – det, metoden returnerer
- `backend/HealthY.Core/streaks/StreakService.cs` – logikken
- `backend/HealthY.Tests/Streaks/StreakServiceTests.cs` – 7 tests

---

## Hvad metoden får, og hvad den giver tilbage

```csharp
StreakResult Calculate(IEnumerable<DateOnly> walkDates, DateOnly today)
```

| | Hvad | Eksempel |
|---|---|---|
| **Ind** `walkDates` | De dage, brugeren har gået | 25/10, 26/10, 27/10 |
| **Ind** `today` | Dagens dato | 27/10 |
| **Ud** `Current` | Dage i træk lige nu | 3 |
| **Ud** `Best` | Længste streak nogensinde | 5 |
| **Ud** `WalkedToday` | Har brugeren gået i dag? | true |

```csharp
public record StreakResult(int Current, int Best, bool WalkedToday);
```
En `record` er en lille klasse, der kun bærer data. Én linje giver tre properties og en constructor.

**Kun datoer, intet klokkeslæt.** `DateOnly` er fx 27/10/2026 uden tid. Det er ligegyldigt, om man gik kl. 8 eller kl. 22: dagen tæller.

Tænk på det som at tælle krydser i en kalender: start ved i dag, og tæl bagud, indtil der mangler et kryds.

---

## Logikken, del for del

### 1. Fjern dubletter
```csharp
var days = walkDates.ToHashSet();
```
Et `HashSet` har to egenskaber, vi bruger:
1. **Ingen dubletter.** 27/10 lagt i to gange ligger der kun én gang, så to ture samme dag tæller som én dag.
2. **Hurtig `Contains`.** "Findes 26/10?" besvares med det samme, i stedet for at gennemsøge hele listen. Vi stiller det spørgsmål mange gange.

> **Ikke det samme som kryptografisk hashing** (SHA-256, adgangskoder), hvor én ændring i input ændrer hele hashen, og man ikke kan regne baglæns. Et HashSet bruger en hash til at finde ting hurtigt, ikke til at beskytte dem.

### 2. Har brugeren gået i dag?
```csharp
var walkedToday = days.Contains(today);
```
`true` eller `false`. Regnes ud tidligt, fordi del 3 bruger den.

### 3. Current: tæl bagud
```csharp
var day = walkedToday ? today : today.AddDays(-1);
var current = 0;
while (days.Contains(day))
{
    current++;
    day = day.AddDays(-1);
}
```
- `? :` er en **ternary**, en kort `if/else`: *hvis* gået i dag, start i dag, *ellers* start i går.
- **Hvorfor i går?** Dagen er ikke slut. Har man gået i går, men ikke endnu i dag, er streaken ikke tabt.
- `while`: så længe der er en tur på dagen, læg 1 til og gå én dag tilbage. Stopper ved første hul.

> ⚠️ **Den svære regel.** Startede vi altid i `today`, ville en bruger, der kun har gået i går, få `Current = 0`, fordi tællingen stopper med det samme. Det er kun et problem, når der *ikke* er gået i dag. Har man gået i dag, giver begge måder samme svar.

### 4. Best: find den længste række
```csharp
var best = 0;
var run = 0;
DateOnly? previous = null;
foreach (var walkDay in days.Order())
{
    run = previous == walkDay.AddDays(-1) ? run + 1 : 1;
    best = Math.Max(best, run);
    previous = walkDay;
}
```
- `Order()` sorterer datoerne fra ældst til nyest.
- For hver dag: var den forrige dag lige før denne? Ja → rækken fortsætter (`run + 1`). Nej → ny række på 1.
- `Math.Max` husker den største række, vi har set.
- `DateOnly?` (med `?`) må være `null`. Det er den ved første dag, hvor der ikke er nogen "forrige".

**Beslutning:** Bedste streak *beregnes* og gemmes ikke. Det er enklest (XPX: gør det enkleste, der virker). Ulempe: sletter brugeren gamle ture, kan bedste streak falde. Gem den først, hvis det bliver et problem.

### 5. Returnér
```csharp
return new StreakResult(current, best, walkedToday);
```

---

## Testene

```csharp
private static readonly DateOnly Today = new DateOnly(2026, 10, 27);
```
**Hvorfor en fast dato?** Testene skal give samme resultat hver gang, uanset hvornår de køres (de skal være *deterministiske*). Brugte vi den rigtige dato, ville "i går = 26/10" være forkert i morgen. Samme grund til, at services får tiden fra `IClock` og aldrig bruger `DateTime.Now`.

**Arrange, Act, Assert**
- **Arrange:** forbered data
- **Act:** kald metoden én gang
- **Assert:** tjek resultatet

**Én regel per test**, og navnet siger hvilken: `Metode_Situation_Forventet`. Fejler `OnlyYesterday_KeepsStreakAtOne`, ved du med det samme, hvilken regel der er brudt.

| Test | Datoer (i dag = 27/10) | Forventet |
|---|---|---|
| `NoWalks_ReturnsZero` | ingen | Current 0, Best 0, WalkedToday false |
| `WalkToday_ReturnsOne` | 27 | Current 1, WalkedToday true |
| `TodayYesterdayAndDayBefore_ReturnsThree` | 25, 26, 27 | Current 3 |
| `OnlyYesterday_KeepsStreakAtOne` | 26 | Current 1, WalkedToday false |
| `GapOfOneDay_StartsOver` | 24, 26, 27 | Current 2 (hul d. 25) |
| `TwoWalksSameDay_CountsAsOneDay` | 27, 27 | Current 1 |
| `OldLongerStreak_IsBest` | 1–5 og 26, 27 | Current 2, Best 5 |

---

## Test-first (TDD) – sådan arbejder vi
1. Skriv én test → kør den → den er **rød**.
2. Skriv lige nok kode til, at den bliver **grøn**. Gerne "snyd", fx `return new StreakResult(0, 0, false);`.
3. Næste test tvinger dig til at skrive mere.
4. Ryd op, når alt er grønt.

---

## Huskeliste (fra quizzen)
- Ingen tur i dag → tæl fra **i går**. Eksempel: ture 25 + 26, i dag 27 → `Current = 2`, ikke 0.
- Et hul på én dag bryder rækken.
- `HashSet` = ingen dubletter + hurtigt opslag. Ikke kryptering.
- Test bruger en fast dato, så de altid giver samme svar.
- Testkode hører til i `HealthY.Tests`, aldrig i `HealthY.Core`. Testen kalder servicen, ikke omvendt.
