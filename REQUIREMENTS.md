# Personal Finance Simulator — Canonical Requirements

> **Source of truth for product requirements.** Read this file before changing financial logic, assumptions, UI behavior, or scope. Update it whenever a requirement, implementation status, or decision changes.

## Baseline

- **Repository:** `vdskevin009/personal-finance-simulator`
- **Default branch:** `main`
- **Baseline verified:** 2026-09-26
- **Code reference:** `5bcd5bbc84aa44dd0e59320ccd01dc9548559819`

## Requirement lifecycle

Statuses: `Proposed`, `Accepted`, `In progress`, `Implemented`, `Verified`, `Deferred`, `Superseded`, `Rejected`.

Rules:
1. Add each new user requirement here before or with implementation.
2. Do not mark a requirement implemented from discussion alone; confirm the code path.
3. Mark `Verified` only after relevant calculations/tests/acceptance checks pass.
4. Preserve superseded assumptions and decisions for traceability.
5. Financial outputs must be described as simulations/estimates rather than forecasts, quotes or individualized advice.

## Product requirements

| ID | Requirement | Status | Implementation notes |
|---|---|---|---|
| PFS-001 | Provide an interactive scenario studio for mortgage overpayment, investing and compound savings growth. | Verified | Current MVP scope. |
| PFS-002 | Support fixed-rate mortgage amortization and additional-payment scenarios. | Implemented | Current MVP. |
| PFS-003 | Compare equal-budget mortgage prepayment versus investing, including investing freed payments after mortgage payoff. | Implemented | Current MVP. |
| PFS-004 | Support standalone compound-savings projections, including negative returns. | Implemented | Current MVP. |
| PFS-005 | Support inflation-adjusted savings views. | Implemented | Current MVP. |
| PFS-006 | Provide yearly charts/tables and CSV export for scenario results. | Implemented | Current MVP. |
| PFS-007 | Allow a scenario to be saved locally for later review. | Implemented | Current MVP. |
| PFS-008 | Currency selection changes labels only unless an explicit FX requirement is added; it must not imply real-time conversion. | Verified | Current limitation. |

## Financial-model constraints

| ID | Requirement | Status | Implementation notes |
|---|---|---|---|
| PFS-MODEL-001 | Results are illustrative scenarios, not forecasts or personalized financial advice. | Verified | Explicit current limitation. |
| PFS-MODEL-002 | Current baseline assumes constant rates/returns unless a future requirement introduces variable schedules. | Verified | Current model. |
| PFS-MODEL-003 | Taxes, fees, insurance, property prices and prepayment penalties are excluded unless explicitly enabled as assumptions in a future version. | Verified | Current limitation. |
| PFS-MODEL-004 | Any new financial assumption must be visible/editable rather than silently embedded in calculations. | Accepted | Canonical modeling principle. |

## Delivery / architecture

| ID | Requirement | Status | Implementation notes |
|---|---|---|---|
| PFS-TECH-001 | Active stack is Blazor WebAssembly with domain logic in `src/Core` and UI in `src/Web`. | Verified | Current repository layout. |
| PFS-TECH-002 | CI must build, run the executable domain test harness and publish before deployment. | Verified | Current delivery contract. |
| PFS-TECH-003 | GitHub Pages is the deployment target; current MVP requires no server, database or paid AI API. | Verified | Current architecture. |
| PFS-TECH-004 | .NET 11 prerelease SDK/package versions must be updated together and tested. | Accepted | Stability constraint. |
| PFS-TECH-005 | Browser-local state must not be treated as secure storage for sensitive financial records. | Verified | Current limitation. |

## Roadmap requirements

| ID | Requirement | Status | Implementation notes |
|---|---|---|---|
| PFS-RM-001 | Consider a scenario comparison library. | Proposed | Roadmap. |
| PFS-RM-002 | Consider irregular contributions and amortization export. | Proposed | Roadmap. |
| PFS-RM-003 | Consider optional, explicit fee/tax assumptions rather than hidden modeling. | Proposed | Roadmap. |

## Open questions / Needs confirmation

- Any future use of personal financial inputs should define whether data remains browser-local and how privacy is preserved before implementation.

## Decision log

| Date | Decision | Result |
|---|---|---|
| 2026-09-26 | Establish `REQUIREMENTS.md` as the canonical requirement source. | Accepted |
| 2026-09-26 | Baseline against `5bcd5bbc84aa44dd0e59320ccd01dc9548559819`. | Accepted |

## Maintenance checklist

Before implementation: read this file, identify affected IDs, add new requirements/assumptions explicitly and record conflicts.

After implementation: update statuses/notes, run calculation/build tests, update the code reference after merge, and keep README/docs aligned.
