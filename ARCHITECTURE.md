# Arkitektur

Health-y er en tre-lags løsning: Vue-frontend → ASP.NET Core API → database. Frontend og database kender ikke hinanden. Al logik og adgangskontrol ligger i API'et.

## Backend: fire projekter

```
HealthY.Api ──────────┐
   │                  ▼
   └──────────► HealthY.Core ◄──── HealthY.Infrastructure
                      ▲
HealthY.Tests ────────┘
```

Alle pile peger ind mod **Core**. Core afhænger ikke af noget.

| Projekt | Ansvar | Må indeholde | Må IKKE indeholde |
|---|---|---|---|
| **Core** | Forretningslogik | Entiteter, interfaces, services, regler | EF Core, Identity, HTTP, `DateTime.Now`, `Random` direkte |
| **Infrastructure** | Database, login, ur | DbContext, repositories, Identity, JWT, `DanishClock`, `RandomPicker` | Forretningslogik |
| **Api** | HTTP | Controllers, DTO'er (`Contracts/`), Program.cs | Forretningslogik, DbContext |
| **Tests** | Unit-tests af Core | Tests, fakes, builders | Database |

### Core er opdelt efter funktion

```
HealthY.Core/
  Walks/     Walk, WalkInput, WalkRules, IWalkRepository, IWalkService, WalkService
  Goals/     Goal, GoalType, DailyStatus, IGoalRepository, IGoalService, GoalService
  Streaks/   StreakResult, IStreakService, StreakService
  Praise/    PraiseMessage, PraiseCategory, PraiseContext, IPraiseMessageRepository, IPraiseService, PraiseService
  Recipes/   Recipe, IRecipeRepository, IRecipeService, RecipeService
  Summary/   WeekSummary, DaySummary, ISummaryService, SummaryService
  Steps/     IStepEstimator, StepEstimator
  Accounts/  ViewMode, UserSettings, ViewModeRules, IAccountRepository, IAccountService, AccountService
  Auth/      IAuthService, AuthResult           (implementeres i Infrastructure)
  Common/    IClock, IRandomPicker, ValidationException
```

## Regler

1. **Ét ansvar per klasse.** StreakService beregner kun streak. PraiseService vælger kun rosebesked. RecipeService finder kun dagens ret.
2. **Tynde controllers.** En controller modtager requesten, kalder ÉN service og returnerer en DTO.
3. **Interfaces og dependency injection.** Services afhænger af `IWalkRepository`, ikke af `DbContext`. Core-services registreres i `Api/Extensions/CoreServiceExtensions.cs`, Infrastructure i `Infrastructure/DependencyInjection.cs`.
4. **DTO'er adskilt fra entiteter.** API'et sender `WalkDto`, aldrig `Walk`.
5. **Rene beregninger.** Logik, der kan, er en ren metode uden database eller tid (`StreakService.Calculate`, `GoalService.CalculateDailyStatus`, `PraiseService.SelectCategory`, `RecipeService.PickForDate`). De er nemmest at teste.
6. **Tid og tilfældighed bag interfaces.** Brug `IClock` og `IRandomPicker`, aldrig `DateTime.Now` eller `Random` direkte. "I dag" er dansk dato.
7. **Testbarhed som målestok.** Kan en service testes med en fake fra `HealthY.Tests/Fakes` uden database, er koblingen lav nok.
8. **Validering to steder.** DTO'er validerer med DataAnnotations (hurtig fejl). Core validerer igen og kaster `ValidationException`, som Api'et laver om til 400 med den danske besked.

## Sikkerhed

- **Alt kræver login** (fallback-policy i Program.cs). Kun `AuthController` har `[AllowAnonymous]`.
- **UserId kommer altid fra tokenet** (`User.GetUserId()`), aldrig fra URL eller body.
- **Repositories filtrerer altid på userId.** En tur, der tilhører en anden, behandles som "findes ikke" (404).
- **Secrets** (connection string, `Jwt:Key`) ligger i user-secrets lokalt og i App Service-indstillinger i Azure. Aldrig i git.
- **CORS** tillader kun de origins, der står i `Cors:AllowedOrigins`.

## Frontend

```
src/
  api.js          ← det ENESTE sted, der kender URL'er
  features/       ← én mappe per funktion
    auth/ walks/ goal/ home/ recipes/ praise/ settings/ privacy/
  shared/         ← komponenter brugt af flere funktioner
  router/
```

- Komponenter kalder funktioner fra `api.js` (fx `getWalks()`) og kender ingen URL'er.
- Tilgængelighed: brødtekst mindst 18 px, knapper mindst 44 × 44 px, kontrast mindst 4,5:1, `<label>` på alle felter, alt kan bruges med tastatur.

## Tests

- Mapper følger Core: `Streaks/StreakServiceTests.cs` osv.
- Navngivning: `Metode_Situation_ForventetResultat`.
- Håndskrevne fakes i `Fakes/`, testdata via `Builders/`.
- Tests markeret `Skip = "TODO"` mangler at blive skrevet.
