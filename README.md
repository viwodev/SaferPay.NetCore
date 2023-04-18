# SaferPay.NetCore Json Api V1.33

This repository is an implementation of the SaferPay.Net library (https://github.com/bmbsqd/saferpay-net), with updates to use .NetCore 6.0 and RestSharp instead of HttpClient. The implementation is based on the latest version of the JSON API, v1.33, which can be found at the following URL: http://saferpay.github.io/jsonapi/#ChapterTransaction.

### What's New
+ Upgrade to .NetCore 6.0
+ HttpClient has been replaced by RestSharp
+ Updated to use the latest version of the JSON API, v1.33
+ BaseUri has been replaced by SandBox mode, and BaseUri will now be generated based on SandBox mode.
+ Constructors have been updated and improved for easier usage.

#### Basic Usage

Init ApiClient;
```csharp
    ISaferPayClient Client = new SaferPayClient("CustomerId", "TerminalId", "UserName", "PassWord", true);
```

Init request based on your method;

```csharp
	string OrderID = "123456";
    InitializeRequest req = new InitializeRequest();
    req.TerminalId = this.ClientId;
    req.Payment = new InitializationPayment(123.45, "TRY", OrderID);
    req.PaymentMeans = new InitializationPaymentMeans(new InitializationCard("9010004150000009", 12, 30, 123, "Card Holder Name"));
    req.ReturnUrl = $"https://localhost/payment/";
```
Call Api ASync
```csharp
	try
    {
        var result = await Client.InitializeAsync(req);
        if (!string.IsNullOrEmpty(result.Token))
        {
	        // Do Stuff
        }
    }
    catch (SaferPayException ex)
    {
		    // Catch Errors
    }
```

Call Api Sync
```csharp
	try
    {
        var result = Client.Initialize(req);
        if (!string.IsNullOrEmpty(result.Token))
        {
	        // Do Stuff
        }
    }
    catch (SaferPayException ex)
    {
		    // Catch Errors
    }
```
    
