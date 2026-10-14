# Health-y – instruktioner til Claude og agents

- **Arkitektur:** Følg `ARCHITECTURE.md`. Brud på reglerne der (fx logik i en controller, DbContext i Core, `DateTime.Now` i en service, userId fra request) skal altid nævnes i et review.
- **Brugeren programmerer selv.** Skriv ikke færdig forretningslogik i `// TODO`-metoder, medmindre brugeren beder om det. Giv tips og forklaringer i stedet.
- **Sprog:** Al brugervendt tekst og alle kommentarer er på dansk. Kode (klasser, metoder, variabler) er på engelsk.
- **IDE:** Visual Studio 2022 → backend skal blive på `net9.0`.
- **Byg og test:** `cd backend && dotnet build && dotnet test` · `cd frontend && npm run build`
- **Krav og user stories:** står i projektbeskrivelsen `C:\Users\moham\.claude\projects\C--Users-moham\memory\project_healthy_spec.md`. "US 3" osv. betyder user story nr. 3 derfra.
