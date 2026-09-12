# Architecture

## Decision

Use standalone Blazor WebAssembly and .NET 11 for C# domain logic with zero-server hosting. This favors low operating cost and an easy portfolio deployment. Server-dependent features are deferred explicitly rather than embedding credentials in the client.

## Components

Finance.Calculate is a pure monthly projection with no UI or storage dependencies. Monthly mortgage rate is nominal annual rate / 12; investment rate is effective annual rate converted with a twelfth root. Payments and contributions occur at month-end; output rounds only for display. Initial investment and monthly budget are equal in both strategies. Net position excludes the same property value on both sides.

Browser UI → C# domain → browser storage. Downloaded backups and issue links are user-initiated data exits. Domain code has no network dependencies.

## Privacy and persistence

Illustrative assumptions, not forecasts or individualized advice. Excludes tax, fees, insurance, property prices and repayment penalties. Constant rates and returns are assumed. Currency selection changes labels, not exchange rates.

Local storage is best-effort, subject to quotas and browser deletion. Errors surface in the UI. App-specific storage keys and cache prefixes avoid accidental collisions, but all apps on one github.io origin can access the same origin storage. Future sensitive data requires an authenticated backend and server-side authorization.

## Testing

The executable harness tests domain boundaries and known scenarios. Release publish verifies Razor compilation, trimming and static assets. Browser smoke checks cover the primary workflow. Tests and publish run before the deploy job; pull requests cannot deploy.

## Deployment

GitHub Actions builds a versioned Pages artifact. A separate job uses pages:write and id-token:write only after build success. Main deploys through the github-pages environment. Pull requests get read-only permissions. Dependency versions are pinned; review updates to .NET RC versions before merging.

## Roadmap

1. Scenario comparison library
2. irregular contributions
3. fees and taxes as explicit optional assumptions
4. inflation-adjusted comparison
5. amortization export.

No paid hosting or external AI calls without Kevin's approval.
