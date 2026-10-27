# Health-y – instruktioner til Claude og agents

- **Arkitektur:** Følg `ARCHITECTURE.md`. Brud på reglerne der (fx logik i en controller, DbContext i Core, `DateTime.Now` i en service, userId fra request) skal altid nævnes i et review.
- **Brugeren programmerer selv.** Skriv ikke færdig forretningslogik i `// TODO`-metoder, medmindre brugeren beder om det. Giv tips og forklaringer i stedet.
- **Forklaringer:** Ingen forklarende kommentarer i færdig kode (hverken `//` eller `///`). Alle forklaringer skrives i `docs/forklaringer/USxx-navn.md` (én fil per user story/emne): koden, hvorfor den er skrevet sådan, og læringspunkter. `// Arrange`, `// Act`, `// Assert` i tests er ok.
- **Sprog:** Al brugervendt tekst og alle kommentarer er på dansk. Kode (klasser, metoder, variabler) er på engelsk.
- **IDE:** Visual Studio 2022 → backend skal blive på `net9.0`.
- **Git:** Arbejd aldrig direkte på `main`. Opret en side-branch før enhver ændring (fx `us3-registrer-gaatur`, `chore/...`, `fix/...`), commit og push dér, og merge til `main` via pull request, når CI er grøn. Ingen `Co-Authored-By: Claude` eller anden Claude-attribution i commits/PR'er.
- **Byg og test:** `cd backend && dotnet build && dotnet test` · `cd frontend && npm run build`
- **Krav og user stories:** står i projektbeskrivelsen `C:\Users\moham\.claude\projects\C--Users-moham\memory\project_healthy_spec.md`. "US 3" osv. betyder user story nr. 3 derfra.
