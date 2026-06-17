# Church Admin App — Dev Doc

## Phase 0 — Environment Setup

### Step 1: .NET SDK + VS Code

- Date: 11-JUN-2026
- .NET version installed: 10.0.301
- Status: ✅ Complete

### Step 2: GitHub Repository

- Date: 11-JUN-2026
- Repo URL: https://github.com/KwabSA/ChurchAdminMVP
- Local branch: main
- Status: ✅ Complete

### Step 3: Blazor Project Created

- Date: 11-JUN-2026
- Template used: dotnet new blazor --interactivity WebAssembly --all-interactive
- .NET version: 10.0.301
- Projects: ChurchAdminMVP (server), ChurchAdminMVP.Client (frontend)
- Status: ✅ Complete

### Step 4: Blazor App Running Locally

- Date: 11-JUN-2026
- Local URL: http://localhost:5046
- Fixed: Removed invalid `using ChurchAdminMVP.Client.Pages` from Program.cs
- Fixed: Added `AllowMissingPrunePackageData=true` to both .csproj files (NET10 preview bug)
- Status: ✅ Complete

---

## Phase 0 Summary

- .NET version: 10.0.301
- IDE: VS Code + C# Dev Kit
- Project type: Blazor Web App with WebAssembly interactivity
- Repo: https://github.com/KwabSA/ChurchAdminMVP
- All environment issues resolved

### Step 5: Supabase Database Created

- Date: 11-JUN-2026
- Project: ChurchAdminMVP
- Region: West EU (Ireland) eu-west-1
- Status: Healthy ✅
- Connection string: stored in local environment only (never committed to git)
- Status: ✅ Complete

### Step 10: Database Migration Applied

- Date: 11-JUN-2026
- Migration: InitialCreate
- Tables confirmed in Supabase: Members, \_\_EFMigrationsHistory
- Columns: Id, FirstName, LastName, Email, PhoneNumber, DateOfBirth, Gender, Address, DateJoined, IsActive
- Note: RLS disabled — to be enabled before production
- Status: ✅ Complete

---

## Phase 0 Complete ✅

All environment setup done. Database live. Ready for API development.

### Step 11: Members API Controller

- Date: 12-JUN-2026
- Endpoints: GET /api/Members, POST /api/Members, GET /api/Members/{id}, PUT /api/Members/{id}
- Tested via Swagger UI
- POST response: 201 Created ✅
- GET response: 200 OK with live Supabase data ✅
- Auto-fields working: dateJoined, isActive ✅
- Status: ✅ Complete

### Security Fix: Git Tracking Cleanup

- Date: 12-JUN-2026
- Issue: appsettings.Development.json was tracked by git despite .gitignore
- Root cause: File was committed before .gitignore rule was in place
- Fix: git rm --cached to untrack without deleting locally
- Lesson: Always verify git ls-files after adding .gitignore rules
- .gitignore now covers: appsettings._.json, bin/, obj/, .vscode/, _.user
- Status: ✅ Resolved

### Step 12: ASP.NET Identity + JWT Setup

- Date: 12-JUN-2026
- Packages: Identity.EntityFrameworkCore, JwtBearer, System.IdentityModel.Tokens.Jwt
- Migration: AddIdentity — created 7 AspNet\* tables in Supabase
- Tip: Use Session pooler port 5432 for migrations, Transaction pooler port 6543 for app
- Status: ✅ Complete

### Step 13: Auth Controller (Register + Login)

- Date: 13-JUN-2026
- Endpoints: POST /api/Auth/register, POST /api/Auth/login
- Register test: 200 OK ✅
- Login test: 200 OK + JWT token returned ✅
- Fix applied: Switched to Session pooler port 5432 — resolves timeout issues
- Status: ✅ Complete

### Step 14: Protected Members API + JWT Auth Complete

- Date: 16-JUN-2026
- Fix applied: Added missing AddAuthentication().AddJwtBearer() block to Program.cs
- Fix applied: Changed Sub claim to ClaimTypes.NameIdentifier for correct mapping
- POST /api/Members: 201 Created with auto-assigned UserId ✅
- GET /api/Members: 200 OK returns user-scoped member profile ✅
- GET without token: 401 Unauthorized ✅
- Status: ✅ Complete

## Phase 1 Backend Summary

| Endpoint                | Status                       |
| ----------------------- | ---------------------------- |
| POST /api/Auth/register | ✅                           |
| POST /api/Auth/login    | ✅ JWT returned              |
| GET /api/Members        | ✅ Auth required             |
| POST /api/Members       | ✅ Auth + UserId auto-linked |
| PUT /api/Members/{id}   | ✅ Auth + owner-only         |
