# SaferPay.NetCore Json Api V1.45

This repository is an implementation of the `SaferPay.Net` library (`https://github.com/bmbsqd/saferpay-net`), with updates to use **.NetCore 6.0** and **RestSharp** instead of HttpClient, and all methods extented by sync and async call. 

The implementation is based on the latest version of the JSON API, v1.43, which can be found at the following URL: `http://saferpay.github.io/jsonapi/#ChapterTransaction`.

You can find Test Cards and explanation of usage at `https://docs.saferpay.com/home/integration-guide/testing-and-go-live#visa-and-v-pay`

### What's New
+ Upgrade to `.NetCore 6.0`
+ HttpClient has been replaced by `RestSharp`
+ Updated to use the latest version of the JSON API, `v1.45`
+ Replaced `BaseUri` with `SandBox` mode, and BaseUri is now generated based on SandBox mode for testing or live.
+ Updated and improved constructors for easier usage.
+ Added descriptions to Properties based on api document.
+ Converted string properties to Enum values.
+ Added Examples and Test Console App in Solution.
+ Added Interface Channels to ease of usage.
+ Added Extensions for most used methods directly use in client.
+ Added `IsSuccess` and `Error` properties in ResultObject.
+ Updated all enum values, models, interfaces.

### Methods
+ Implemented all methods
+ Payment Page Methods : `Initialize`, `Assert`
+ Transaction Methods : `Initialize`, `Authorize`, `AuthorizeDirect`, `AuthorizeReferenced`, `Capture`, `MultipartCapture`, `AssertCapture`, `MultipartFinalize`, `Refund`, `AssertRefund`, `RefundDirect`, `Cancel`, `RedirectPayment`, `AssertRedirectPayment`, `Inquire`, `AlternativePayment`, `QueryAlternativePayment`        
+ Secure Card Data : `Insert`, `AssertInsert`, `InsertDirect`, `Update`, `Delete`
+ Batch : `Close`
+ Omni Channel : `InsertAlias`, `AcquireTransaction`

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