# Personal Finance Simulator

An interactive scenario studio for mortgage overpayment, investing and compound savings growth.

[Open the app](https://vdskevin009.github.io/personal-finance-simulator/) · [CI](https://github.com/vdskevin009/personal-finance-simulator/actions) · [Phone workflow](docs/PHONE-WORKFLOW.md)

## MVP features

Fixed-rate amortization; equal-budget extra-payment versus investment comparison; freed payments invested after payoff; standalone savings projection; negative returns; inflation-adjusted savings; yearly charts and tables; CSV export; local saved scenario.

## Run locally

Install the SDK pinned in global.json: .NET 11 RC1 (11.0.100-rc.1.26425.128). This is a prerelease SDK; update the SDK and ASP.NET package versions together after testing.

```sh
dotnet run --project src/Web
# Meaningful domain tests, using a dependency-free executable harness:
dotnet run --project tests/Core.Tests -c Release
dotnet publish src/Web -c Release -o artifacts/site
```

The harness exits nonzero on a failed assertion. It is deliberately run with **dotnet run**, not dotnet test.

## Repository layout

- src/Core: domain rules and calculations
- src/Web: responsive Blazor WebAssembly UI, persistence adapter and PWA assets
- tests/Core.Tests: executable domain tests
- docs: architecture, roadmap and phone instructions
- .github/workflows/ci.yml: PR checks and main-branch deployment
- scripts/setup.sh: Linux cloud environment setup

## Hosting and delivery

Public GitHub repository + GitHub Pages. No server, database, paid AI API or paid infrastructure. Standard public-repository GitHub-hosted runners are used. Changes on a feature branch go through a PR; merge to main builds, tests and deploys. Manual redeploy: Actions → Build, test and deploy → Run workflow → main.

Pages source must be **GitHub Actions** in Settings → Pages. The build changes the base href before publishing so offline integrity hashes match the Pages subpath. Rollback by reverting the problematic merge in a new PR; the revert deployment replaces the current build.

## Honest limitations

Illustrative assumptions, not forecasts or individualized advice. Excludes tax, fees, insurance, property prices and repayment penalties. Constant rates and returns are assumed. Currency selection changes labels, not exchange rates.

Browser storage is scoped to the origin and profile, not a security boundary between apps on the same github.io origin. Do not store sensitive production data. There are no analytics or third-party scripts. Offline assets are cached after a successful first load; close all app tabs and reopen after a new deployment to activate the waiting service worker.

## Next steps

Scenario comparison library; irregular contributions; fees and taxes as explicit optional assumptions; inflation-adjusted comparison; amortization export.

See [architecture](docs/ARCHITECTURE.md).
