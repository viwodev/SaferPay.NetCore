# SaferPay.NetCore Test & Examples (Json Api V1.54)

The two test projects for [SaferPay.NetCore](../README.md), built against the JSON API **v1.54** and targeting **.NET 8.0 / .NET 10.0**.

For the full API reference and usage snippets, read the [root README](../README.md). This page only covers how to run the test artifacts.

## Console playground (`SaferPay.Test`)

A small console app that wires up an `ISaferPayClient` against the SaferPay sandbox and lets you trigger requests from a menu (Payment Page, Transaction, Secure Card Data, ...). The bundled `success.html` / `failed.html` pages stand in for return URLs.

Run it from the repository root:

```bash
dotnet run --project SaferPay.Test
```

Sandbox credentials live in [`TestConfig.cs`](TestConfig.cs) and point at the public Viwo test account. Replace them with your own to test a real account.

## Automated tests (`SaferPay.Tests`)

The [`SaferPay.Tests`](../SaferPay.Tests) xUnit project holds the real test suite:

+ **Unit** : request/response building, routing, extensions, settings and value types (offline).
+ **Integration** : exercises the live HTTP pipeline against the SaferPay sandbox.

Run everything from the repository root:

```bash
dotnet test SaferPay.Tests/SaferPay.Tests.csproj
```

Integration tests use the public Viwo sandbox account by default. Override or skip them with environment variables:

| Variable | Purpose |
| --- | --- |
| `SAFERPAY_CUSTOMER_ID` | Override sandbox Customer Id |
| `SAFERPAY_TERMINAL_ID` | Override sandbox Terminal Id |
| `SAFERPAY_USERNAME` | Override sandbox API username |
| `SAFERPAY_PASSWORD` | Override sandbox API password |
| `SAFERPAY_SKIP_INTEGRATION` | Set to `1` to skip integration tests (fully offline run) |
