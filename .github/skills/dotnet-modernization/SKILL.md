# Modernize .NET solutions
Use this skill whenever the user asks for help modernizing a .NET solution. 

## Approach
- Always propose **one improvement at a time**. Wait for user approval before applying any change.

Always follow the following steps when suggesting improvements and exicuting them:
### 1. Discover (first interaction only, or when asked to re-scan)

Before suggesting anything, briefly scan the codebase to understand it:
- Find all `*.csproj` / `*.fsproj` / `*.vbproj` and read `<TargetFramework(s)>`, `<LangVersion>`, `<Nullable>`, `<ImplicitUsings>`.
- Check for `global.json` (pinned SDK) and `Directory.Build.props` / `Directory.Packages.props`.
- Note app type per project: console / web (ASP.NET Core) / library / desktop / test.
- Note test framework if present (xUnit / NUnit / MSTest).
- Note package versions for major dependencies (EF Core, ASP.NET Core, Serilog, etc.).

Summarize findings in **one short paragraph + a small table** (project → TFM → notable settings). Do NOT dump file contents.

### 2. Prioritize

Build a mental backlog of improvements, ordered by impact and risk. Recommended priority:

1. **TFM upgrade toward .NET 10** (if currently on .NET 8 or older LTS / older). One project at a time, starting with leaf projects (libraries with no dependents), then apps, then tests.
2. **`<LangVersion>` alignment** with the new TFM (only after TFM moves).
3. **Project file hygiene**: SDK-style projects, `<Nullable>enable</Nullable>`, `<ImplicitUsings>enable</ImplicitUsings>`, `<TreatWarningsAsErrors>` where appropriate, central package management (`Directory.Packages.props`).
4. **Modern C# language features** (offer one feature at a time per file/area):
   - file-scoped namespaces
   - primary constructors
   - collection expressions (`[1, 2, 3]`)
   - raw string literals (`"""..."""`)
   - target-typed `new()`
   - pattern matching / switch expressions
   - `required` members, `init` setters, records for DTOs
   - C# 14 (NET 10): extension members, `field` accessor, `?.=`, partial ctors/events
5. **API & framework modernization**:
   - `System.Text.Json` over `Newtonsoft.Json` (where viable)
   - `HttpClientFactory` over `new HttpClient()`
   - `Microsoft.Extensions.Logging` (`ILogger<T>`) over ad-hoc logging
   - Minimal APIs / `WebApplication.CreateBuilder` for ASP.NET Core
   - Async-all-the-way; remove sync-over-async; pass `CancellationToken`
   - `ArgumentNullException.ThrowIfNull` / `ArgumentException.ThrowIfNullOrWhiteSpace`
   - `using` declarations / `await using`
   - `IAsyncEnumerable<T>` for streamed results
6. **Best practices**:
   - Nullable reference types annotations
   - Records for DTOs and value objects
   - DI registration hygiene (lifetimes; avoid captive dependencies)
   - Resilient I/O (Polly / `ResiliencePipeline`)
   - Structured logging with scopes; no `Console.WriteLine` in libraries
   - Observability hooks (OpenTelemetry) where appropriate
7. **Testing modernization**: latest xUnit / NUnit / MSTest, parameterized tests, FluentAssertions if already present, AAA structure.
8. **Security & supply chain**: out-of-date packages with known CVEs, `dotnet list package --vulnerable`, secrets in config.

### 3. Propose ONE Improvement

Use this exact template for every suggestion:

```
### Suggestion: <short title>

**What:** <one-sentence description of the change>
**Why:** <one or two sentences on the benefit — perf, safety, clarity, future-proofing>
**Where:** <file(s) and rough scope — e.g. "CountingApp/Program.cs, ~10 lines">
**Risk:** Low | Medium | High — <one line on what could break>
**Effort:** Trivial | Small | Medium | Large

Shall I apply this change? (yes / no / skip / show me the diff first)
```

Examples of well-shaped openers:
- *"Shall I upgrade `CountingApp` from .NET 8 to .NET 10? It's a leaf console app with no dependents, so it's the safest starting point."*
- *"Shall I convert `PirateSalute/Program.cs` to a file-scoped namespace? It's a one-line change with zero runtime impact."*
- *"Shall I replace the manual null check on line 23 with `ArgumentNullException.ThrowIfNull(name)`? It's the modern idiom and one line shorter."*

### 4. On User Approval

- Apply ONLY the proposed change. Nothing else.
- Build the affected project(s) with `dotnet build` to confirm it still compiles.
- If a test project exists for the changed code, run the relevant tests.
- Report: ✅ applied / ❌ failed (with the exact error), files changed, build result, test result.
- Then ask: *"Ready for the next suggestion?"* — and wait.

### 5. On User Decline / Skip

- Acknowledge briefly ("Understood, skipping.").
- Move to the next item in the backlog and propose it using the same template.
- Don't re-pitch a declined suggestion in the same session unless the user asks.

## TFM Upgrade Playbook (when proposing a .NET version bump)

When proposing a TFM upgrade for a single project, the suggestion must include:

- Current TFM → proposed TFM.
- Whether the project has dependents (other projects in the solution that reference it) — upgrade leaf projects first.
- Whether `global.json` pins an older SDK (if yes, flag it; do not change `global.json` without separate approval).
- Whether `<LangVersion>` is explicitly set (if yes, mention it will likely need a follow-up suggestion to align).
- Known breaking changes for the jump (link to the official "breaking changes" doc when relevant, e.g. https://learn.microsoft.com/dotnet/core/compatibility/).
- Plan: change `<TargetFramework>`, run `dotnet restore`, `dotnet build`, run tests.

Never bundle the TFM bump with language-feature adoption in the same suggestion.
