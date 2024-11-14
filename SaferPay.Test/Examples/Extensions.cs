using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.PaymentPage;
using SaferPay.Models.Transaction;
using Console = Colorful.Console;

namespace SaferPay.Test.Examples;

public class Extensions
{
    /// <summary>
    /// Init Payment Page
    /// </summary>
    public void InitPaymentPage()
    {
        ISaferPayClient Client = new SaferPayClient(TestConfig.CustomerId, TestConfig.TerminalId, TestConfig.ApiUserName, TestConfig.ApiPassword, TestConfig.SandBox);

        string OrderID = "123456";

        InitializePaymentPageRequest req = new InitializePaymentPageRequest();
        req.TerminalId = TestConfig.TerminalId;
        req.Payment = new Payment(123.45M, "TRY", OrderID);
        req.ReturnUrl = $"{TestConfig.WebPage}payment-page?orderId={OrderID}";

        var result = Client.InitializePaymentPage(req);
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

    }

    /// <summary>
    /// Init Payment Page Async
    /// </summary>
    public async void InitPaymentPageAsync()
    {
        ISaferPayClient Client = new SaferPayClient(TestConfig.CustomerId, TestConfig.TerminalId, TestConfig.ApiUserName, TestConfig.ApiPassword, TestConfig.SandBox);

        string OrderID = "123456";

        InitializePaymentPageRequest req = new InitializePaymentPageRequest();
        req.TerminalId = TestConfig.TerminalId;
        req.Payment = new Payment(123.45M, "TRY", OrderID);
        req.ReturnUrl = $"{TestConfig.WebPage}payment-page?orderId={OrderID}";

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

    }

    public void InitTransaction()
    {
        ISaferPayClient Client = new SaferPayClient(TestConfig.CustomerId, TestConfig.TerminalId, TestConfig.ApiUserName, TestConfig.ApiPassword, TestConfig.SandBox);

        string OrderID = "123456";

        InitializeRequest req = new InitializeRequest();
        req.TerminalId = TestConfig.TerminalId;
        req.Payment = new Payment(123.45M, "TRY", OrderID);
        req.PaymentMeans = new Card("9010004150000009", 12, 30, "123", "Card Holder Name");
        req.ReturnUrl = $"{TestConfig.WebPage}transaction?orderId={OrderID}";

        var result = Client.InitializeTransaction(req);
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

    }

    public void InitTransactionAlternative()
    {
        ISaferPayClient Client = new SaferPayClient(TestConfig.CustomerId, TestConfig.TerminalId, TestConfig.ApiUserName, TestConfig.ApiPassword, TestConfig.SandBox);

        string OrderID = "123456";

        InitializeRequest req = new InitializeRequest(TestConfig.TerminalId, 123.45M, "TRY", OrderID, $"{TestConfig.WebPage}transaction?orderId={OrderID}").SetCard("9010004150000009", 12, 30, "123", "Card Holder Name");

        var result = Client.InitializeTransaction(req);
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

    }

    public async void InitTransactionAsync()
    {
        ISaferPayClient Client = new SaferPayClient(TestConfig.CustomerId, TestConfig.TerminalId, TestConfig.ApiUserName, TestConfig.ApiPassword, TestConfig.SandBox);

        string OrderID = "123456";

        InitializeRequest req = new InitializeRequest();
        req.TerminalId = TestConfig.TerminalId;
        req.Payment = new Payment(123.45M, "TRY", OrderID);
        req.PaymentMeans = new Card("9010004150000009", 12, 30, "123", "Card Holder Name");
        req.ReturnUrl = $"{TestConfig.WebPage}transaction?orderId={OrderID}";

        var result = await Client.InitializeTransactionAsync(req);
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

    }
}
