# Health-y

En enkel og letlæselig hjemmeside, der hjælper voksne på 35–80 år med at gå mere.

## Struktur

- `backend/` – ASP.NET Core Web API (.NET 9)
  - `HealthY.Api` – controllers og opsætning
  - `HealthY.Core` – forretningslogik og interfaces (afhænger ikke af noget)
  - `HealthY.Infrastructure` – database og repositories
  - `HealthY.Tests` – xUnit-tests
- `frontend/` – Vue 3 + Vite
  - `src/api.js` – det eneste sted, der kender API-adressen (`VITE_API_URL`)
  - `src/features/` – én mappe per funktion (walks, goal, recipes, praise)

## Kom i gang

Backend:

```
cd backend
dotnet build
dotnet test
dotnet run --project HealthY.Api
```

Frontend:

```
cd frontend
npm install
npm run dev
```
