# SaferPay.NetCore Json Api V1.52

This repository is an implementation of the [SaferPay.Net](https://github.com/bmbsqd/saferpay-net) library, with updates to use **.NetCore 8.0** and **RestSharp** instead of HttpClient. All methods have been extended with sync and async calls.

The implementation is based on the latest version of the JSON API, **v1.52**, which can be found at the following URL: http://saferpay.github.io/jsonapi/#ChapterTransaction

You can find Test Cards and explanation of usage at: https://docs.saferpay.com/home/integration-guide/testing-and-go-live#visa-and-v-pay

### Test Pages

**Create Test Account**
```
https://test.saferpay.com/BO/SignUp
```

**Login Test Account**
```
https://test.saferpay.com/BO/Login
```

### What's New
+ Upgrade to `.NetCore 8.0`
+ HttpClient has been replaced by `RestSharp`
+ Updated to use the latest version of the JSON API, `v1.52`
+ Replaced `BaseUri` with `SandBox` mode. BaseUri is now generated based on SandBox mode for testing or live environments.
+ Updated and improved constructors for easier usage.
+ Added descriptions to Properties based on the API documentation.
+ Converted string properties to Enum values.
+ Added Examples and Test Console App in the Solution.
+ Added Interface Channels for ease of usage.
+ Added Extensions for the most used methods for direct use in the client.
+ Added `IsSuccess` and `Error` properties in ResultObject.
+ Updated all enum values, models, and interfaces.

### Methods
Implemented all methods:

+ **Payment Page Methods:** `Initialize`, `Assert`
+ **Transaction Methods:** `Initialize`, `Authorize`, `AuthorizeDirect`, `AuthorizeReferenced`, `Capture`, `MultipartCapture`, `AssertCapture`, `MultipartFinalize`, `Refund`, `AssertRefund`, `RefundDirect`, `Cancel`, `RedirectPayment`, `AssertRedirectPayment`, `Inquire`, `AlternativePayment`, `QueryAlternativePayment`, `DccInquiry`        
+ **Secure Card Data:** `Insert`, `AssertInsert`, `InsertDirect`, `Update`, `Delete`, `Inquire`
+ **Batch:** `Close`
+ **Omni Channel:** `InsertAlias`, `AcquireTransaction`
+ **Saferpay Management API:** `Licensing CustomerLicense`, `PaymentPageConfig GetConfigurations`, `SaferpayFieldsAccessToken CreateAccessToken`, `SaferpayFieldsAccessToken DeleteAccessToken`, `SecurePayGate Create SingleUsePaymentLink`, `SecurePayGate SingleUsePaymentLink`, `SecurePayGate Delete SingleUsePaymentLink`, `Terminal GetTerminal`, `Terminals GetTerminals`, `TransactionReporting GetTransactions`

### Global Settings and Usage (With Client Extensions)

Define Settings;
```csharp
SaferPay.Config.Settings.Default.Username = "ApiUserName";
SaferPay.Config.Settings.Default.Password = "ApiPassword";
SaferPay.Config.Settings.Default.TerminalId = "TerminalId";
SaferPay.Config.Settings.Default.CustomerId = "CustomerId";
SaferPay.Config.Settings.Default.SandBox = true;
```

Get Client Instance;
```csharp
ISaferPayClient Client = SaferPay.Config.Settings.Client();
```

Initialize request for Payment Page;
```csharp
string OrderID = "123456";

InitializePaymentPageRequest req = new InitializePaymentPageRequest();
req.TerminalId = TestConfig.TerminalId;
req.Payment = new Payment(123.45M, "TRY", OrderID);
req.ReturnUrl = $"{TestConfig.WebPage}payment-page?orderId={OrderID}";
```

Call Api Async;
```csharp
var result = await Client.InitializePaymentPageAsync(req);
if (result != null && result.IsSuccess)
{
    // Success
    Console.Write("Response Successful : ");
    Console.WriteLine(result.Json());
}
else if (result != null)
{
    // Failed
    Console.Write("Response Failed : ");
    Console.WriteLine(result.Error.Json());
}
else
{
    // Error
    Console.Write("Error !");
}
```

Call Api Sync;
```csharp
var result = Client.InitializePaymentPage(req);
if (result != null && result.IsSuccess)
{
    // Success
    Console.Write("Response Successful : ");
    Console.WriteLine(result.Json());
} else if(result != null)
{
    // Failed
    Console.Write("Response Failed : ");
    Console.WriteLine(result.Error.Json());
} else
{
    // Error
    Console.Write("Error !");
}
```
  

### Basic Usage With Interface Channels


Initialize the ApiClient;
```csharp
ISaferPayClient Client = new SaferPayClient("CustomerId", "TerminalId", "UserName", "PassWord", true);
```

Get Interface Channel to use, example based on Transaction;
```csharp
ITransaction payment = Client.Transaction;
```

Created Credit Card request;
```csharp
string OrderID = "123456";

InitializeRequest req = new InitializeRequest(TestConfig.TerminalId, 123.45M, "TRY", OrderID, $"{TestConfig.WebPage}transaction?orderId={OrderID}").SetCard("9010004150000009", 12, 30, "123", "Card Holder Name");
```

Call Api Async;
```csharp
var result = await payment.InitializeAsync(req);
if (result != null && result.IsSuccess)
{
    // Success
    Console.Write("Response Successful : ");
    Console.WriteLine(result.Json());
}
else if (result != null)
{
    // Failed
    Console.Write("Response Failed : ");
    Console.WriteLine(result.Error.Json());
}
else
{
    // Error
    Console.Write("Error !");
}
```

Call Api Sync;
```csharp
var result = payment.Initialize(req);
if (result != null && result.IsSuccess)
{
    // Success
    Console.Write("Response Successful : ");
    Console.WriteLine(result.Json());
} else if(result != null)
{
    // Failed
    Console.Write("Response Failed : ");
    Console.WriteLine(result.Error.Json());
} else
{
    // Error
    Console.Write("Error !");
}
```

### Changelog

`v1.52.01`
+ Updated library target framework to `.NET 8.0`
+ Removed unsupported `.NET 6.0` and legacy test runtime targets
+ Improved overall package compatibility with current and future .NET runtimes
+ Fixed recursive `Dispose()` implementation causing `StackOverflowException`
+ Fixed missing `_jsonSerializerSettings` initialization in the 4-argument constructor
+ Improved `RestClient` lifecycle management to prevent socket/resource leaks under load
+ Fixed exception rethrow handling to preserve original stack traces
+ Normalized `CreditCardExpiration` year handling across constructor, setters and parsing
+ Fixed `CreditCardExpiration.Parse()` producing invalid `MMYYYY` values instead of `MMYY`
+ Improved `CreditCardExpiration.ToString()` formatting consistency
+ Updated package metadata and NuGet packaging configuration
+ Improved GitHub Actions build, validation and NuGet publishing workflow
+ Updated package validation and build pipeline for `.NET 8`
+ General reliability, maintainability and runtime compatibility improvements

`v1.52`
+ Updated to use the latest version of the JSON API, `v1.52`
+ Added `Saferpay Management API`.
+ Added `PaymentPage GetConfigurations` method to Saferpay Management API
+ Added `WITH_SUCCESSFUL_THREE_DS_CHALLENGE` as a valid value for the field Condition
+ Added `MastercardTLID` to the `IssuerReference` container in the response
+ removed `PayerId` from the `PayPal` container

`v1.51`
+ Updated to use the latest version of the JSON API, `v1.51`
+ added `PAYPAL` as valid value for field Type in `Alias/Insert`
+ added `ONLINE_CHALLENGED` as valid value for field Type of container `Check` in `Alias/Insert`
+ removed `OK_AUTHENTICATED` as valid value from field `Result` of container `CheckResult`. 
+ removed `INVOICE` as valid value from `PaymentMethods` in `PaymentPage/Initialize`
+ added fields `Authenticated` and `AuthenticationType` to container `AuthenticationResult`. Removed field `Result` from container in return.
+ added field `FundingSource` to container `Card`
+ field `CountryCode` in container `ForeignRetailer` is now mandatory.

`v1.50`
+ Updated to use the latest version of the JSON API, `v1.50`
+ Added value `ONLINE_STRONG` to Type in the `Check` container and added new container `ExternalThreeDS` in `Alias/InsertDirect`
+ Added `GIFTCARD` as valid value for the field `PaymentMethods`
+ Introduced a new function to provide Dynamic Currency Conversion (`DCC`) inquiry details for your customer: `Transaction\DccInquiry`
+ The payment methods `GIROPAY`, `PAYDIREKT`, `SOFORT` and `WLCRYPTOPAYMENTS` are no longer supported.
+ `Transaction/AuthorizeDirect` is extended with the new subcontainer `DCC`, which references the response from `Transaction/DccInquiry` and payer's decision whether he accepts or declines `DCC` offer
+ Added `WERO` as valid value for the field `PaymentMethods`
+ Added `HolderName` and `IBAN` to the BankAccount container in `PaymentPage/Assert`
+ `Transaction/RefundDirect` is extended with the new subcontainer `BankAccount`. This is a required container for PostFinance Instant Payout

`v1.46`
+ Updated to use the latest version of the JSON API, `v1.46`
+ Added new subcontainer `ExternalThreeDS` to container `Authentication`. This affects the following requests: `Transaction/AuthorizeDirect`
+ Updated `AuthorizeDirect` method to use the new `ExternalThreeDS` subcontainer.

`v1.45.01`
+ Added `REKA` as alternative payment method to `PaymentPagePaymentMethods`.
