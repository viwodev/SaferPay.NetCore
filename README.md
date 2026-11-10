# SaferPay.NetCore (Json Api V1.55)

An implementation of the [SaferPay.Net](https://github.com/bmbsqd/saferpay-net) library, updated to target **.NET 8.0 / .NET 10.0** and to use **RestSharp** instead of HttpClient. Every method is available in both sync and async form.

It tracks the JSON API **v1.55** ([reference](http://saferpay.github.io/jsonapi/#ChapterTransaction)). Test cards and usage are documented on the [SaferPay integration guide](https://docs.saferpay.com/home/integration-guide/testing-and-go-live#visa-and-v-pay).

## What's New

+ Multi-targets `.NET 8.0` and `.NET 10.0`
+ `HttpClient` replaced by `RestSharp`
+ Tracks the latest JSON API, `v1.55`
+ `BaseUri` replaced by a `SandBox` flag (the base URL is derived from it)
+ Simpler constructors and property descriptions taken from the API docs
+ String properties converted to enums
+ Interface channels and extension methods for the most common calls
+ `IsSuccess` and `Error` on every result object
+ Example console app included in the solution

## Methods

+ **Payment Page:** `Initialize`, `Assert`
+ **Transaction:** `Initialize`, `Authorize`, `QueryPaymentMeans`, `AdjustAmount`, `AuthorizeDirect`, `AuthorizeReferenced`, `Capture`, `MultipartCapture`, `AssertCapture`, `MultipartFinalize`, `Refund`, `AssertRefund`, `RefundDirect`, `Cancel`, `Inquire`, `AlternativePayment`, `QueryAlternativePayment`, `DccInquiry`
+ **Secure Card Data:** `Insert`, `AssertInsert`, `InsertDirect`, `Update`, `Delete`, `Inquire`
+ **Batch:** `Close`
+ **Omni Channel:** `InsertAlias`, `AcquireTransaction`
+ **Management API:** `Licensing CustomerLicense`, `PaymentPageConfig GetConfigurations`, `SaferpayFieldsAccessToken CreateAccessToken`, `SaferpayFieldsAccessToken DeleteAccessToken`, `SecurePayGate Create/Get/Delete SingleUsePaymentLink`, `Terminal GetTerminal`, `Terminals GetTerminals`, `TransactionReporting GetTransactions`

## Usage

### 1. Create a client

Either configure the global settings and pull a client from them:

```csharp
SaferPay.Config.Settings.Default.CustomerId = "CustomerId";
SaferPay.Config.Settings.Default.TerminalId = "TerminalId";
SaferPay.Config.Settings.Default.Username   = "ApiUserName";
SaferPay.Config.Settings.Default.Password   = "ApiPassword";
SaferPay.Config.Settings.Default.SandBox    = true;

ISaferPayClient client = SaferPay.Config.Settings.Client();
```

Or build one directly:

```csharp
ISaferPayClient client = new SaferPayClient("CustomerId", "TerminalId", "UserName", "Password", sandBox: true);
```

### 2. Build a request

```csharp
string orderId = "123456";

var request = new InitializePaymentPageRequest
{
    TerminalId = TestConfig.TerminalId,
    Payment    = new Payment(123.45M, "TRY", orderId),
    ReturnUrl  = $"{TestConfig.WebPage}payment-page?orderId={orderId}",
};
```

### 3. Send it (async or sync)

```csharp
var result = await client.InitializePaymentPageAsync(request);
// sync equivalent:
// var result = client.InitializePaymentPage(request);
```

### 4. Handle the result

Every call returns a result exposing `IsSuccess`, the typed response and an `Error` object:

```csharp
if (result != null && result.IsSuccess) {
    Console.WriteLine(result.Json());        // success
}
else if (result != null) {
    Console.WriteLine(result.Error.Json());  // API returned an error
}
else {
    Console.WriteLine("Request failed.");    // null / transport error
}
```

### Interface channels

Each API group is also reachable as a typed channel on the client, which keeps related calls together:

```csharp
ITransaction transaction = client.Transaction;

var request = new InitializeRequest(
        TestConfig.TerminalId, 123.45M, "TRY", orderId,
        $"{TestConfig.WebPage}transaction?orderId={orderId}")
    .SetCard("9010004150000009", 12, 30, "123", "Card Holder Name");

var result = await transaction.InitializeAsync(request);
// sync: transaction.Initialize(request);
```

The result is handled exactly as shown in step 4.

## Tests

The solution ships two test projects at the repository root:

+ **`SaferPay.Tests`** : automated xUnit suite (`Unit` + sandbox `Integration`). Run it with:

  ```bash
  dotnet test SaferPay.Tests/SaferPay.Tests.csproj
  ```

  Integration tests hit `test.saferpay.com` with the public Viwo sandbox account by default. Override it with the `SAFERPAY_CUSTOMER_ID`, `SAFERPAY_TERMINAL_ID`, `SAFERPAY_USERNAME` and `SAFERPAY_PASSWORD` environment variables, or set `SAFERPAY_SKIP_INTEGRATION=1` for a fully offline run.

+ **`SaferPay.Test`** : interactive console playground that demonstrates the API end to end. See [`SaferPay.Test/README.md`](SaferPay.Test/README.md).

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for the full version history.
