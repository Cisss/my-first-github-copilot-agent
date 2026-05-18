<!-- Ahoy! This here be the ship's log (README) for the repo. Arrr! -->
# my-first-github-copilot-agent

A playground for building **custom GitHub Copilot agents** and a couple of small demo apps they helped produce. Most of the crew speak in pirate dialect — ye've been warned. Arrr!

## Apps

### CountingApp — C# console app

A .NET 10 console application in [CountingApp/](CountingApp/) that counts from **1 to 10**, attaching a unique, randomly-shuffled pirate exclamation to each number (e.g. `3, Shiver me timbers!`) and finishing with a triumphant `Enteriiiing!`.

- Stack: .NET 10, C# 14
- Entry point: [CountingApp/Program.cs](CountingApp/Program.cs)
- Run: `dotnet run --project CountingApp`

### treasure-api — Node.js REST API

A tiny Express server in [treasure-api/](treasure-api/) for trackin' pirate treasure in memory (no database — restart the ship and the chest empties).

- Stack: Node.js + Express
- Endpoints: `POST /treasure`, `GET /treasure`, `GET /treasure/:id`, `DELETE /treasure/:id`
- Run: `npm install` then `npm start` from [treasure-api/](treasure-api/)
- Full docs: [treasure-api/README.md](treasure-api/README.md)

## Custom Copilot Agents

All agents live in [.github/agents/](.github/agents/). The pirate-themed agents form a small fleet with a clear chain of command; the others are focused specialists.

| Agent | File | Role |
| --- | --- | --- |
| **Admiral** | [admiral.agent.md](.github/agents/admiral.agent.md) | Grand orchestrator. Commands the fleet end-to-end from planning to deployment. Pure pirate dialect. |
| **Captain** | [captain.agent.md](.github/agents/captain.agent.md) | Master planner and architect. Designs the voyage in detail but never writes code. |
| **First Mate** | [first-mate.agent.md](.github/agents/first-mate.agent.md) | Lead developer. Writes the code and tests, flags when the Captain's charts are wrong. |
| **Lookout** | [lookout.agent.md](.github/agents/lookout.agent.md) | Paranoid QA watchman. Catalogs defects as **KRAKEN**, **Rough Seas**, or **Barnacles**. |
| **Pirate Developer** | [pirate.agent.md](.github/agents/pirate.agent.md) | Coding agent that sprinkles pirate-speak comments into every file it touches. |
| **PR agent** | [pr-creator.agent.md](.github/agents/pr-creator.agent.md) | Specialist that builds clear, fun-to-read GitHub pull requests via the `create-pr` skill. |
| **C# Expert** | [CSharpExpert.agent.md](.github/agents/CSharpExpert.agent.md) | Non-pirate specialist for clean, idiomatic .NET / C# work and best practices. |

## Repository layout

```
.github/agents/   # Custom Copilot agent definitions
CountingApp/      # .NET 10 console app (pirate counting)
treasure-api/     # Express REST API for pirate treasure
```

## Notes

- Build artifacts (`bin/`, `obj/`, `node_modules/`) and IDE files are excluded via [.gitignore](.gitignore).
- The pirate dialect in code comments and agent prompts is intentional — feature, not bug. Yarr!
