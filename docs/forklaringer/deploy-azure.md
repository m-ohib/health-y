# Deploy til Azure

Health-y kører gratis i Azure. Alt er beskrevet i kode (`infra/main.bicep`), så det kan genskabes, og deploy sker automatisk fra GitHub.

```
Bruger → https://ca-healthy....azurecontainerapps.io  (senere health-y.dk)
            │
            ▼
   Azure Container App  "ca-healthy"   (Sweden Central, skalerer til 0)
   ┌──────────────────────────────────┐
   │ ASP.NET Core API  /api/...       │
   │ + Vue-filer (wwwroot)  /         │
   └──────────────────────────────────┘
            │ Managed Identity (intet password)
            ▼
   Azure SQL "healthy"  (gratis tilbud, pauser selv)
```

---

## Hvorfor sådan? (beslutninger)

| Beslutning | Hvorfor |
|---|---|
| **Container Apps**, ikke App Service | App Service F1 kan ikke få eget domæne, og B1 koster ca. 90 kr./md. Container Apps er gratis inden for den månedlige kvote og giver gratis HTTPS på eget domæne. |
| **Vue og API i samme container** | Static Web Apps (gratis frontend-hosting) findes ikke i de regioner, skolens Azure-politik tillader (Sweden Central, France Central, Germany West Central, Norway East, Switzerland North). Samme adresse betyder også ingen CORS og nemmere sikkert login med cookies senere. Koden er stadig to separate projekter. |
| **Sweden Central** | Tilladt af skolens politik og tæt på Danmark. |
| **Azure SQL, gratis tilbud** | Gratis op til en månedlig grænse. Pauser efter 60 min. uden brug, så første besøg kan tage op til et halvt minut. |
| **Managed Identity til databasen** | Appen logger ind som sig selv. Der findes intet password, der kan lække. Microsofts anbefaling. |
| **Entra-only på SQL** | SQL-brugernavn/password er slået helt fra. Kun Entra-konti (dig og appen) kan logge ind. |
| **GitHub OIDC** | GitHub logger ind i Azure med et kortlivet token. Ingen nøgler gemt i GitHub. Azure stoler kun på `main`-branchen i `m-ohib/health-y`. |
| **Infrastructure as Code (Bicep)** | Klik i portalen kan ikke gentages. Går noget galt, kan alt slettes og genskabes med én kommando. |
| **ghcr.io** | GitHub Container Registry er gratis for offentlige repos. Azure Container Registry koster penge. |

---

## Ressourcer (resource group `rg-healthy`)

| Navn | Type | Rolle |
|---|---|---|
| `ca-healthy` | Container App | Kører appen |
| `cae-healthy-…` | Container Apps Environment | "Huset" appen bor i |
| `log-healthy-…` | Log Analytics | Logs (maks 0,1 GB/dag, så det forbliver gratis) |
| `sql-healthy-…` / `healthy` | SQL server + database | Data |
| `id-healthy-github` | Managed Identity | Den identitet GitHub Actions deployer som |

---

## Sådan kommer ny kode online

1. Du merger en PR til `main`.
2. CI bygger og tester backend og frontend.
3. CI bygger containeren (`Dockerfile`) og lægger den på `ghcr.io/m-ohib/health-y` med commit-id som tag.
4. CI logger ind i Azure (OIDC) og beder Container App'en bruge det nye image.
5. CI kalder `/health`, indtil appen svarer. Svarer den ikke, bliver CI rød.

På en PR bygges containeren også, men den pushes og deployes ikke. Så fanges fejl i `Dockerfile`, før de når `main`.

### Dockerfile i tre trin
1. **frontend:** `npm ci` + `npm run build` → `dist/`
2. **backend:** `dotnet publish` af API'et
3. **final:** kun runtime (ingen SDK), API + Vue-filer i `wwwroot`, kører som ikke-root bruger på port 8080

Det kaldes et *multi-stage build*: det færdige image indeholder kun det nødvendige, så det er lille og har færre sikkerhedshuller.

### Hvordan én app serverer både Vue og API (`Program.cs`)
| Adresse | Hvad svarer |
|---|---|
| `/` og fx `/walks` | Vue (`index.html`), så Vue-router virker ved genindlæsning |
| `/assets/...` | Vue-filer |
| `/api/...` | Controllers. Ukendt `/api`-adresse giver 404, ikke Vue-siden |
| `/health` | "Kører appen?" (rører ikke databasen) |
| `/health/db` | "Kan appen nå databasen?" (vækker databasen, så kald den kun manuelt) |

---

## Kommandoer

Azure CLI ligger i `C:\Program Files\Microsoft SDKs\Azure\CLI2\wbin\az.cmd`.

**Se hvad Bicep vil ændre (ændrer intet):**
```powershell
az deployment group what-if -g rg-healthy -f infra\main.bicep `
  -p containerImage=ghcr.io/m-ohib/health-y:latest sqlAdminLogin=<din e-mail> sqlAdminObjectId=<dit object id>
```
**Anvend Bicep:** samme kommando med `create` i stedet for `what-if`.
> Bicep sætter image til det, du angiver. Brug `:latest`, så den ikke ruller tilbage til et gammelt image.

**Dit object id:** `az ad signed-in-user show --query id -o tsv`

**Logs fra appen:**
```powershell
az containerapp logs show -n ca-healthy -g rg-healthy --follow
```

**Give appen adgang til databasen** (er gjort én gang; skal gentages, hvis appen genskabes):
```sql
CREATE USER [ca-healthy] FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER [ca-healthy];
ALTER ROLE db_datawriter ADD MEMBER [ca-healthy];
```
Køres med `sqlcmd --authentication-method ActiveDirectoryAzCli` som SQL-administrator, efter at din IP midlertidigt er åbnet i SQL-firewallen. Luk firewallen igen bagefter.

---

## GitHub-variabler
Under *Settings → Secrets and variables → Actions → Variables*: `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_SUBSCRIPTION_ID`. De er id'er, ikke hemmeligheder. Uden dem springes deploy over.

---

## Endnu ikke gjort
- **health-y.dk:** A-record + TXT-record hos Domeneshop, derefter gratis certifikat i Container Apps.
- **Migrations:** hvordan databasetabellerne oprettes i Azure (appen har kun læse/skrive-rettigheder i dag).
- **JWT-nøgle:** skal ligge som secret i Container App'en, når login bygges.

---

## Huskeliste
- Container = appen pakket med alt, den skal bruge. Kører ens på din pc, i CI og i Azure.
- Managed Identity = appen har sin egen "konto" i Azure. Intet password.
- OIDC = GitHub beviser, hvem den er, med et kortlivet token. Ingen gemte nøgler.
- Bicep = infrastruktur som kode. Kan gentages og slettes.
- Skolens politik bestemmer regionerne. Tjek altid, hvad kontoen må, før du bygger.
