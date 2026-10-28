# US 13 – Skøn over skridt

> Som bruger uden skridttæller vil jeg se et skøn over mine skridt.
> Ud fra minutter (ca. 80–100 skridt/min). Vises altid med "ca.". Kun når brugeren ikke selv har skrevet skridt.

**Skrevet af:** dig selv (test først, så logik).

**Filer**
- `backend/HealthY.Core/Steps/IStepEstimator.cs` – interfacet
- `backend/HealthY.Core/Steps/StepEstimator.cs` – logikken
- `backend/HealthY.Tests/Steps/StepEstimatorTests.cs` – 2 tests

---

## Hvad gør metoden?

```csharp
public const int StepsPerMinute = 90;

public int Estimate(int minutes)
{
    return (int)(minutes * StepsPerMinute);
}
```

**Lommeregneren:**
```
       IND                     UD
  10 (minutter)  →  × 90  →  900 (skridt)
```
- Det, der går **ind**, er altid **minutter**.
- Det, der kommer **ud**, er altid **skridt**.
- `Estimate` estimerer *skridt*, ikke minutter.

**Hvor kommer × 90 fra?** Et menneske tager ca. 80–100 skridt i minuttet, når man går roligt (spec'en). 90 er midten. Ligesom en bil der kører 50 km/t: 2 timer = 2 × 50 = 100 km.

| minutes | Udregning | Resultat |
|---|---|---|
| 0 | 0 × 90 | 0 |
| 10 | 10 × 90 | 900 |
| 20 | 20 × 90 | 1.800 |
| 600 (maks) | 600 × 90 | 54.000 |

### `const`
`StepsPerMinute` er en **konstant**: værdien kan ikke ændres, mens programmet kører. Fordelen er, at tallet 90 kun står ét sted. Skal det ændres til 95, ændrer man én linje.

### `(int)` – en cast
En cast laver en værdi om til en anden type. Her er den **ikke nødvendig**, fordi `int × int` allerede giver en `int`. Koden virker med og uden. En cast skal bruges, når man går fra fx `double` (kommatal) til `int` (heltal). Du kan fjerne den, når du har lyst.

---

## Testene

| Test | Ind | Forventet ud |
|---|---|---|
| `Estimate_TenMinutes_Returns900` | 10 | 900 |
| `Estimate_ZeroMinutes_ReturnsZero` | 0 | 0 |

`Estimate_ZeroMinutes_ReturnsZero` er en **grænseværdi-test**: den tester kanten af det mulige. Agenterne roste, at du tænkte på den.

### Fejlen du lavede undervejs (og lærte af)
Først stod der `estimator.Estimate(900)`. Det spørger: *"hvor mange skridt er 900 minutter?"* → 900 × 90 = **81.000**, ikke 900. Testen ville fejle, selvom logikken var rigtig.

**Regel:** I parentesen står **input** (minutter). Det forventede **output** (skridt) står kun i `Assert.Equal(forventet, faktisk)`.

### Rød → grøn (TDD)
1. Testene skrevet først → kørt → **røde** med `NotImplementedException`. Det var rigtigt: logikken fandtes ikke.
2. Én linje logik → **grønne**.

### Kan gøres senere (forslag fra agenterne)
- Tilføj `// Arrange`, `// Act`, `// Assert` som i streak-testene.
- Saml testene med `[Theory]` og `[InlineData]`, så flere tal deler én test:
  ```csharp
  [Theory]
  [InlineData(0, 0)]
  [InlineData(10, 900)]
  [InlineData(600, 54000)]
  public void Estimate_Minutes_ReturnsMinutesTimes90(int minutes, int expected)
  ```

---

## Beslutning: negative minutter testes ikke her
**Din pointe:** man kan ikke gå et negativt antal minutter. API'et afviser allerede alt under 1 minut:
```csharp
[Range(WalkRules.MinMinutes, WalkRules.MaxMinutes, ErrorMessage = "Minutter skal være mellem 1 og 600.")]
```
Validering hører til **ét sted**: der hvor input kommer ind (API + `WalkService.Validate`). Derfor tester vi negative minutter i US 3, ikke i StepEstimator (XPX: YAGNI – byg ikke det, du ikke har brug for).

---

## Hvor bruges den?
- **US 7 / GoalService:** hvis målet er skridt, og en tur ikke har skridt, bruges skønnet.
- **Visning:** skønnet vises **altid med "ca."**, fx "ca. 900 skridt", og kun når brugeren ikke selv har skrevet skridt.

---

## Huskeliste
- `Estimate`: **minutter ind → × 90 → skridt ud**.
- Input i parentesen, forventet svar i `Assert`.
- `const` = tallet står ét sted.
- `(int)` er en cast; unødvendig ved `int × int`.
- Validering ét sted: der hvor data kommer ind.
