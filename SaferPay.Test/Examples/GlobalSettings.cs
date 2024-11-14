using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Transaction;
using Console = Colorful.Console;

namespace SaferPay.Test.Examples;

public class GlobalSettings
{
    public ISaferPayClient Client;


    public void Setup()
    {
        SaferPay.Config.Settings.Default.Username = TestConfig.ApiUserName;
        SaferPay.Config.Settings.Default.Password = TestConfig.ApiPassword;
        SaferPay.Config.Settings.Default.TerminalId = TestConfig.TerminalId;
        SaferPay.Config.Settings.Default.CustomerId = TestConfig.CustomerId;
        SaferPay.Config.Settings.Default.SandBox = true;
        Client = SaferPay.Config.Settings.Client();
    }

    public async void InitializeAsync()
    {
        string OrderID = "ABC123456";
        InitializeRequest req = new InitializeRequest();
        req.TerminalId = TestConfig.TerminalId;
        req.Payment = new Payment(123.45M, "TRY", OrderID);
        req.PaymentMeans = new PaymentMeans(new Card("9010004150000009", 12, 30, "123", "Card Holder Name"));
        req.ReturnUrl = $"{TestConfig.WebPage}transaction?orderId={OrderID}";

        InitializeResponse result = await Client.Transaction.InitializeAsync(req);
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

    public void Initialize()
    {
        string OrderID = "ABC123456";
        InitializeRequest req = new InitializeRequest();
        req.TerminalId = TestConfig.TerminalId;
        req.Payment = new Payment(123.45M, "TRY", OrderID);
        req.PaymentMeans = new PaymentMeans(new Card("9010004150000009", 12, 30, "123", "Card Holder Name"));
        req.ReturnUrl = $"{TestConfig.WebPage}transaction?orderId={OrderID}";

        InitializeResponse result = Client.Transaction.Initialize(req);
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
