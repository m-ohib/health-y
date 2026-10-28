# Rettelser fra code review (28. okt. 2026)

To høje fund fra `code-reviewer`. Ingen af dem gav fejl i dag, men begge ville give problemer senere.

---

## 1. Enums sendes som tekst i JSON

**Fil:** `backend/HealthY.Api/Program.cs`

```csharp
using System.Text.Json.Serialization;
...
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
```

**Problemet:** Et enum er en liste af faste valg, fx `ViewMode.Simple` og `ViewMode.Extended`. Som standard sender ASP.NET Core dem som **tal** i JSON. Frontenden bruger **tekst**.

| C# | Før | Efter |
|---|---|---|
| `ViewMode.Simple` | `0` | `"Simple"` |
| `ViewMode.Extended` | `1` | `"Extended"` |

Uden rettelsen ville `PUT /api/goal` med `"type": "Minutes"` give 400, så snart US 6 og US 10 blev koblet til frontenden.

**Hvordan:** `AddJsonOptions` ændrer, hvordan API'et laver JSON. `JsonStringEnumConverter` er en "oversætter", der skriver enums som deres navn, og læser navnet tilbage igen.

---

## 2. RandomPicker flyttet fra Core til Infrastructure

**Før:** `backend/HealthY.Core/Common/RandomPicker.cs`
**Efter:** `backend/HealthY.Infrastructure/Randomness/RandomPicker.cs`

**Problemet:** ARCHITECTURE.md siger, at Core ikke må bruge `Random` direkte. Den rigtige implementering skal ligge i Infrastructure, mens Core kun kender interfacet. Det er samme mønster som med tid:

| | Interface (Core) | Rigtig implementering (Infrastructure) |
|---|---|---|
| Tid | `IClock` | `DanishClock` |
| Tilfældighed | `IRandomPicker` | `RandomPicker` |

**Hvorfor?** `PraiseService` kender kun `IRandomPicker`. I tests får den `FakeRandomPicker`, som altid vælger det samme, så testen giver samme resultat hver gang. I den rigtige app får den `RandomPicker`.

**Ændringer:**
- Filen er flyttet med `git mv`, så historikken følger med. Namespace er nu `HealthY.Infrastructure.Randomness`.
- Registreringen er flyttet fra `Api/Extensions/CoreServiceExtensions.cs` til `Infrastructure/DependencyInjection.cs`, lige under `DanishClock`.
- ARCHITECTURE.md nævner nu `RandomPicker` under Infrastructure.

**Hvorfor mappen hedder `Randomness` og ikke `Random`:** Hed namespacet `...Random`, ville `Random.Shared` inde i filen pege på namespacet i stedet for .NET's `Random`-klasse, og koden ville ikke kompilere.

---

## Huskeliste
- Enum i C# → som standard et tal i JSON. `JsonStringEnumConverter` gør det til tekst.
- Core = regler og interfaces. Infrastructure = de rigtige implementeringer (database, ur, tilfældighed).
- Flyt filer med `git mv`, så git ved, at det er samme fil.
