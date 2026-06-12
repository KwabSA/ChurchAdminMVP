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
