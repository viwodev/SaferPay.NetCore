using SaferPay.Extensions;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Management;
using SaferPay.Models.Transaction;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using color = System.Drawing.Color;
using Console = Colorful.Console;

namespace SaferPay.Test;

public static class Helpers
{

    public static ISaferPayClient SaferPayClient;

    public static Dictionary<string, string> CurrentTokens = new Dictionary<string, string>();

    public static void CreateClient()
    {
        SaferPayClient = new SaferPayClient(TestConfig.CustomerId, TestConfig.TerminalId, TestConfig.ApiUserName, TestConfig.ApiPassword, true);
    }

    public static Interfaces CurrentInterfaces = Interfaces.Interfaces;

    public static bool ExitConsole = false;

    public static void CLRF()
    {
        Console.WriteLine();
    }

    public static void PrintCursor()
    {
        CLRF();
        Console.Write(" >> ", Color.Green);
    }

    public static void ProcessCommand(string command)
    {
        Helpers.CurrentInterfaces = Interfaces.ProcessCommand;
        switch (command)
        {
            case "m":
                PrintMenu();
                return;

            case "q":
            case "exit":
                Console.WriteLine();
                Console.Write("Press any key to exit ...", Color.Orange);
                Console.ReadLine();
                ExitConsole = true;
                return;

            case "cls":
            case "clear":
                Console.Clear();
                break;

            default:
                break;
        }

    }

    public static void PrintMenu(bool clear = true)
    {
        if (clear) Console.Clear();
        Helpers.CurrentInterfaces = Interfaces.Interfaces;

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(" Interfaces", color.Green);
        Console.WriteLine();
        Console.WriteLine(" 1. Payment Page");
        Console.WriteLine(" 2. Transaction");
        Console.WriteLine(" 3. Secure Card Data");
        Console.WriteLine(" 4. Batch");
        Console.WriteLine(" 5. OmniChannel");
        Console.WriteLine(" 6. Management Api");
        Console.WriteLine();
        Console.WriteLine(" 7. Show Tokens");
        Console.WriteLine(" 8. Json Converter");
        Console.WriteLine(" 9. Test Credit Card Expiration");
        Console.WriteLine(" 0. Exit");
        Console.WriteLine();
        Console.WriteLine(" Please select an option ...");

        PrintCursor();

        var option = Console.ReadLine();
        int optionID = 0;

        if (int.TryParse(option, out optionID) && optionID > 0 && optionID <= 9)
        {
            switch (optionID)
            {
                case 1:
                    PaymentPage();
                    return;

                case 2:
                    TransactionPage();
                    return;

                case 6:
                    ManagementApiPage();
                    return;

                case 7:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("*** Listing Tokens ...", color.Green);

                    if (Helpers.CurrentTokens.Count > 0)
                    {
                        foreach (var item in Helpers.CurrentTokens)
                        {
                            Console.WriteLine($"Order Id : {item.Key}, Token : {item.Value}", color.Green);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No Tokens Found !", color.Yellow);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue", color.Gray);
                    Console.ReadLine();
                    PrintMenu();
                    break;

                case 8:
                    var model = new Payer()
                    {
                        AcceptHeader = "text/html",
                        ColorDepth = "16bits",
                        Id = "REF123456",
                        IpAddress = "127.0.0.1",
                        JavaEnabled = true,
                        JavaScriptEnabled = true,
                        LanguageCode = Enums.Languages.Turkish,
                        ScreenWidth = 2176,
                        ScreenHeight = 1440,
                        UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0"

                    };

                    var jsonString = model.ToJson();

                    Console.WriteLine();
                    Console.WriteLine(jsonString, color.Green);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue", color.Gray);
                    Console.ReadLine();
                    PrintMenu();
                    break;

                case 9:
                    TestCreditCardExpiration();
                    return;

                case 0:
                    ExitConsole = true;
                    return;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Please select an option between 1 and 8 !", color.Red);

                    PrintMenu();
                    break;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option between 1 and 7 !", color.Red);

            PrintMenu();
        }
    }

    enum ManagementApiMenu : int
    {
        Back = 0,
        LicensingCustomerLicense = 1,
        LicensingCustomerLicenseConfiguration = 2,
        PaymentPageConfigGetConfigurations = 3,
        SaferpayFieldsAccessTokenCreateAccessToken = 4,
        SaferpayFieldsAccessTokenDeleteAccessToken = 5,
        SecurePayGateCreateSingleUsePaymentLink = 6,
        SecurePayGateSingleUsePaymentLink = 7,
        TerminalDetails = 8,
        Terminals = 9,
        Transations = 10,
    }

    enum TransactionMenu : int
    {
        Back = 0,

        InitWithCard,
        Init,

        InitAndAuthWithCard,
        InitAndAuth,

        InitFullWithCard,
        InitFull,

        Authorize,
        Capture,
        Cancel,
        Refund,

        Inquiry,

        AssertCapture,
        AssertRefund,

        QueryPaymentMeans,
        AdjustAmount,

        MultiPartFinalize

    }

    public static void TestCreditCardExpiration()
    {
        Console.Clear();
        Console.WriteLine("*** CreditCardExpiration Tests ...", color.Gray);
        Console.WriteLine();

        var tests = new List<(string Name, string Expected, string Actual)>
        {
            ("Constructor 2030/12", "1230", new CreditCardExpiration(2030, 12).ToString()),
            ("Constructor 30/12", "1230", new CreditCardExpiration(30, 12).ToString()),
            ("Parse 12/2030", "1230", CreditCardExpiration.Parse("12/2030").ToString()),
            ("Parse 12/30", "1230", CreditCardExpiration.Parse("12/30").ToString()),
            ("Setter Year 2030", "1230", CreateBySetter(2030, 12).ToString()),
            ("Setter Year 30", "1230", CreateBySetter(30, 12).ToString()),
        };

        foreach (var test in tests)
        {
            var passed = test.Expected == test.Actual;
            Console.Write($"{test.Name} => ", color.Gray);
            Console.Write(
                passed ? "PASS" : "FAIL",
                passed ? color.LimeGreen : color.Red
            );
            Console.WriteLine($" | Expected: {test.Expected}, Actual: {test.Actual}", color.Gray);
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue ...", color.Gray);
        Console.ReadLine();

        PrintMenu();
    }

    private static CreditCardExpiration CreateBySetter(int year, int month)
    {
        var expiration = new CreditCardExpiration
        {
            Month = month,
            Year = year
        };

        return expiration;
    }

    public static void ManagementApiPage(bool clear = true)
    {
        if (clear) Console.Clear();
        Helpers.CurrentInterfaces = Interfaces.ManagementApi;

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(" Management API", color.Green);
        Console.WriteLine();
        Console.WriteLine(" <- Back [0]", color.Red);
        Console.WriteLine();
        Console.Write(" Licensing CustomerLicense"); Console.WriteLine($" [{(int)ManagementApiMenu.LicensingCustomerLicense}]", color.Gray);
        Console.Write(" Licensing CustomerLicense Configuration"); Console.WriteLine($" [{(int)ManagementApiMenu.LicensingCustomerLicenseConfiguration}]", color.Gray);
        Console.Write(" Payment Page Config Get Configurations"); Console.WriteLine($" [{(int)ManagementApiMenu.PaymentPageConfigGetConfigurations}]", color.Gray);
        Console.WriteLine();
        Console.Write(" Saferpay Fields AccessToken Create AccessToken"); Console.WriteLine($" [{(int)ManagementApiMenu.SaferpayFieldsAccessTokenCreateAccessToken}]", color.Gray);
        Console.Write(" Saferpay Fields AccessToken Delete AccessToken"); Console.WriteLine($" [{(int)ManagementApiMenu.SaferpayFieldsAccessTokenDeleteAccessToken}]", color.Gray);
        Console.WriteLine();
        Console.Write(" SecurePay Gate Create Single Use Payment Link"); Console.WriteLine($" [{(int)ManagementApiMenu.SecurePayGateCreateSingleUsePaymentLink}]", color.Gray);
        Console.Write(" SecurePay Gate Single Use Payment Link"); Console.WriteLine($" [{(int)ManagementApiMenu.SecurePayGateSingleUsePaymentLink}]", color.Gray);
        Console.WriteLine();
        Console.Write(" Terminal GetTerminal"); Console.WriteLine($" [{(int)ManagementApiMenu.TerminalDetails}]", color.Gray);
        Console.Write(" Terminals GetTerminals"); Console.WriteLine($" [{(int)ManagementApiMenu.Terminals}]", color.Gray);
        Console.WriteLine();
        Console.Write(" TransactionReporting GetTransactions"); Console.WriteLine($" [{(int)ManagementApiMenu.Transations}]", color.Gray);

        Console.WriteLine();
        Console.WriteLine();
        Console.Write(" Please select an option : ", color.Yellow);
        var option = Console.ReadLine();
        int optionID = 0;
        if (int.TryParse(option, out optionID))
        {
            ManagementApiMenu menu = (ManagementApiMenu)optionID;
            switch (menu)
            {
                case ManagementApiMenu.Back:
                    // Go Back
                    PrintMenu();
                    return;

                case ManagementApiMenu.LicensingCustomerLicense:
                    LicensingCustomerLicense();
                    return;

                case ManagementApiMenu.LicensingCustomerLicenseConfiguration:
                    LicensingCustomerLicenseConfiguration();
                    return;

                case ManagementApiMenu.PaymentPageConfigGetConfigurations:
                    PaymentPageConfigGetConfigurations();
                    return;

                case ManagementApiMenu.SecurePayGateCreateSingleUsePaymentLink:
                    SecurePayGateCreateSingleUsePaymentLink();
                    return;

                case ManagementApiMenu.SecurePayGateSingleUsePaymentLink:
                    SecurePayGateSingleUsePaymentLink();
                    return;

                case ManagementApiMenu.Terminals:
                    TerminalsGetTerminals();
                    return;

                case ManagementApiMenu.TerminalDetails:
                    TerminalGetTerminal();
                    return;

                case ManagementApiMenu.SaferpayFieldsAccessTokenCreateAccessToken:
                    SaferpayFieldsAccessTokenCreateAccessToken();
                    return;

                case ManagementApiMenu.SaferpayFieldsAccessTokenDeleteAccessToken:
                    SaferpayFieldsAccessTokenDeleteAccessToken();
                    return;

                case ManagementApiMenu.Transations:
                    TransactionReportingGetTransactions();
                    return;

                default:
                    ManagementApiPage();
                    break;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option !", color.Red);
            TransactionPage();
        }
    }


    public static void TransactionPage(bool clear = true)
    {
        if (clear) Console.Clear();
        Helpers.CurrentInterfaces = Interfaces.Transaction;

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(" Transaction", color.Green);
        Console.WriteLine();
        Console.WriteLine(" <- Back [0]", color.Red);
        Console.WriteLine();
        Console.Write(" Initialize (With Test Card)"); Console.WriteLine($" [{(int)TransactionMenu.InitWithCard}]", color.Gray);
        Console.Write(" Initialize"); Console.WriteLine($" [{(int)TransactionMenu.Init}]", color.Gray);
        Console.Write(" Initialize -> Authorize (With Test Card)"); Console.WriteLine($" [{(int)TransactionMenu.InitAndAuthWithCard}]", color.Gray);
        Console.Write(" Initialize -> Authorize"); Console.WriteLine($" [{(int)TransactionMenu.InitAndAuth}]", color.Gray);
        Console.Write(" Initialize -> Authorize -> Capture (With Test Card)"); Console.WriteLine($" [{(int)TransactionMenu.InitFullWithCard}]", color.Gray);
        Console.Write(" Initialize -> Authorize -> Capture"); Console.WriteLine($" [{(int)TransactionMenu.InitFull}]", color.Gray);
        Console.WriteLine();
        Console.Write(" Authorize"); Console.WriteLine($" [{(int)TransactionMenu.Authorize}]", color.Gray);
        Console.Write(" Capture"); Console.WriteLine($" [{(int)TransactionMenu.Capture}]", color.Gray);
        Console.Write(" Cancel"); Console.WriteLine($" [{(int)TransactionMenu.Cancel}]", color.Gray);
        Console.Write(" Refund"); Console.WriteLine(" [17]", color.Gray);
        Console.WriteLine();
        Console.Write(" Inquiry"); Console.WriteLine($" [{(int)TransactionMenu.Inquiry}]", color.Gray);
        Console.WriteLine();
        Console.Write(" Assert Capture"); Console.WriteLine($" [{(int)TransactionMenu.AssertCapture}]", color.Gray);
        Console.Write(" Assert Refund"); Console.WriteLine($" [{(int)TransactionMenu.AssertRefund}]", color.Gray);
        Console.WriteLine();
        Console.Write(" Query Payment Means"); Console.WriteLine($" [{(int)TransactionMenu.QueryPaymentMeans}]", color.Gray);
        Console.Write(" Adjust Amount"); Console.WriteLine($" [{(int)TransactionMenu.AdjustAmount}]", color.Gray);
        Console.WriteLine();
        Console.Write(" Multi Part Finalize"); Console.WriteLine($" [{(int)TransactionMenu.MultiPartFinalize}]", color.Gray);


        //Console.WriteLine(" 16. Query Alternative Payment");
        Console.WriteLine();

        //Console.WriteLine(" 18. Authorize Direct");


        Console.WriteLine();
        Console.Write(" Please select an option : ", color.Yellow);

        //PrintCursor();

        var option = Console.ReadLine();
        int optionID = 0;
        if (int.TryParse(option, out optionID))
        {
            TransactionMenu menu = (TransactionMenu)optionID;
            switch (menu)
            {
                case TransactionMenu.Back:
                    // Go Back
                    PrintMenu();
                    return;

                case TransactionMenu.InitFullWithCard:
                    // Initialize
                    Console.WriteLine("Initialize >> Authorize >> Capture (With Test Card) >>", color.Green);
                    Console.Write(">> Please Enter Amount (Ex: 1230 for 12.30): ", color.Yellow);
                    var a1 = Console.ReadLine();
                    InitializeTransaction(a1, true);
                    return;

                case TransactionMenu.InitFull:
                    // Initialize
                    Console.WriteLine("Initialize >> Authorize >> Capture (No Card Data) >>", color.Green);
                    Console.Write(">> Please Enter Amount (Ex: 1230 for 12.30): ", color.Yellow);
                    var a2 = Console.ReadLine();
                    InitializeTransaction(a2, false);
                    return;

                case TransactionMenu.InitWithCard:
                    // Initialize
                    Console.WriteLine("Initialize Only (With Test Card) >>", color.Green);
                    Console.Write(">> Please Enter Amount (Ex: 1230 for 12.30): ", color.Yellow);
                    var a3 = Console.ReadLine();
                    InitializeTransaction(a3, true, "init");
                    return;

                case TransactionMenu.Init:
                    // Initialize
                    Console.WriteLine("Initialize Only (No Card Data) >>", color.Green);
                    Console.Write(">> Please Enter Amount (Ex: 1230 for 12.30): ", color.Yellow);
                    var a4 = Console.ReadLine();
                    InitializeTransaction(a4, false, "init");
                    return;

                case TransactionMenu.InitAndAuthWithCard:
                    // Initialize
                    Console.WriteLine("Initialize >> Authorize Only (With Test Card) >>", color.Green);
                    Console.Write(">> Please Enter Amount (Ex: 1230 for 12.30): ", color.Yellow);
                    var a5 = Console.ReadLine();
                    InitializeTransaction(a5, true, "auth");
                    return;

                case TransactionMenu.InitAndAuth:
                    // Initialize
                    Console.WriteLine("Initialize >> Authorize Only (No Card Data) >>", color.Green);
                    Console.Write(">> Please Enter Amount (Ex: 1230 for 12.30): ", color.Yellow);
                    var a6 = Console.ReadLine();
                    InitializeTransaction(a6, false, "auth");
                    return;

                case TransactionMenu.Authorize:
                    // Authorize
                    Console.WriteLine("Authorize Request >>", color.Green);
                    Console.Write(">> Please Enter Token: ", color.Yellow);
                    var token = Console.ReadLine();
                    Authorize(token);
                    return;

                case TransactionMenu.Capture:
                    // Capture
                    Console.WriteLine("Capture Request >>", color.Green);
                    Console.Write(">> Please Enter Transaction ID: ", color.Yellow);
                    var trnID = Console.ReadLine();
                    Capture(trnID);
                    return;

                case TransactionMenu.AssertCapture:
                    // Assert Capture
                    Console.WriteLine("Assert Capture >>", color.Green);
                    Console.Write(">> Please Enter Capture ID: ", color.Yellow);
                    var asc = Console.ReadLine();
                    AssertCapture(asc);
                    return;

                case TransactionMenu.Inquiry:
                    // inquiry
                    Console.WriteLine("Inquiry >>", color.Green);
                    Console.Write(">> Please Enter Transaction ID: ", color.Yellow);
                    var inquiryId = Console.ReadLine();
                    Inquiry(inquiryId);
                    return;

                case TransactionMenu.Cancel:
                    // Cancel
                    Console.WriteLine("Cancel >>", color.Green);
                    Console.Write(">> Please Enter Transaction ID: ", color.Yellow);
                    var cancelId = Console.ReadLine();
                    Cancel(cancelId);
                    return;

                case TransactionMenu.MultiPartFinalize:
                    // MultiPartFinalize
                    Console.WriteLine("Multi Part Finalize >>", color.Green);
                    Console.Write(">> Please Enter Transaction ID: ", color.Yellow);
                    var mpi = Console.ReadLine();
                    MultiPartFinalize(mpi);
                    return;

                case TransactionMenu.AssertRefund:
                    // Assert Refund
                    Console.WriteLine("Assert Refund Request >>", color.Green);
                    Console.Write(">> Please Enter Transaction Id: ", color.Yellow);
                    var arfID = Console.ReadLine();
                    AssertRefund(arfID);
                    return;

                case TransactionMenu.Refund:
                    // Refund
                    Console.WriteLine("Refund Request >>", color.Green);
                    Console.Write(">> Please Enter Transaction Id: ", color.Yellow);
                    var rfTrn = Console.ReadLine();
                    Console.Write(">> Please Enter Refund Amount (Ex: 1230 for 12.30 ): ", color.Yellow);
                    var rfAmount = Console.ReadLine();
                    Refund(rfTrn, rfAmount);
                    return;


                default:
                    TransactionPage();
                    break;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option !", color.Red);
            TransactionPage();
        }
    }

    public static void PaymentPage(bool clear = true)
    {
        if (clear) Console.Clear();
        Helpers.CurrentInterfaces = Interfaces.PaymentPage;

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(" Payment Page", color.Green);
        Console.WriteLine();
        Console.WriteLine(" <- Back [0]", color.Red);
        Console.WriteLine();
        Console.WriteLine(" 1. PaymentPage Initialize");
        Console.WriteLine(" 2. PaymentPage Assert");
        Console.WriteLine();
        Console.WriteLine(" Please select an option ...");

        PrintCursor();

        var option = Console.ReadLine();
        int optionID = 0;
        if (int.TryParse(option, out optionID) && optionID >= 0 && optionID <= 3)
        {
            switch (optionID)
            {

                case 0:
                    // Go Back
                    PrintMenu();
                    return;

                case 1:
                    // Payment Page Initialize
                    PaymentPageInitialize();
                    return;

                case 2:
                    // Payment Page Assert
                    Console.Write("Please Enter Token For Assert : ", color.Yellow);
                    var token = Console.ReadLine();
                    PaymentPageAssert(token);
                    return;

                default:
                    PaymentPage();
                    break;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option !", color.Red);
            PaymentPage();
        }
    }

    /// <summary>
    /// Refund
    /// </summary>
    /// <param name="transactionId"></param>
    /// <param name="amount"></param>
    public async static void Refund(string transactionId, string amount)
    {
        if (string.IsNullOrEmpty(transactionId))
        {
            Console.Clear();
            Console.WriteLine("Transaction ID is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Refund ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.RefundAsync(new Models.Transaction.RefundRequest(transactionId, amount.Replace(".", "").Replace(",", ",,"), TestConfig.Currency));

        Console.WriteLine();

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Assert Refund
    /// </summary>
    /// <param name="captureID"></param>
    public async static void AssertRefund(string transactionID)
    {
        if (string.IsNullOrEmpty(transactionID))
        {
            Console.Clear();
            Console.WriteLine("Transaction ID is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Assert Refund ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.AssertRefundAsync(new AssertRefundRequest(transactionID));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Payment Page (Assert)
    /// </summary>
    /// <param name="token"></param>
    public async static void PaymentPageAssert(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            Console.Clear();
            Console.WriteLine("Token is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            PaymentPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Asserting Payment Page ...", color.Gray);
        var payment = SaferPayClient.PaymentPage;
        var response = await payment.AssertAsync(new Models.PaymentPage.AssertRequest(token));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        PaymentPage();
    }

    /// <summary>
    /// Payment Page (Init)
    /// </summary>
    public async static void PaymentPageInitialize()
    {
        Console.Clear();
        Console.WriteLine("*** Initializigin Payment Page ...", color.Gray);
        var payment = SaferPayClient.PaymentPage;
        var request = new SaferPay.Models.PaymentPage.InitializePaymentPageRequest();

        var uid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        var url = $"{TestConfig.WebPage}payment-page?orderId={uid}";

        request.TerminalId = TestConfig.TerminalId;
        request.ReturnUrl = url;
        request.Payment = new Models.Core.Payment();
        request.Payment.Amount = new Models.Core.Amount(100, TestConfig.Currency);
        request.Payment.Description = "Test Product";
        request.Payment.OrderId = uid;
        request.Payment.PayerNote = "Test Notes For Payer";

        request.PaymentMethods = new List<Enums.PaymentPagePaymentMethods>() {
            Enums.PaymentPagePaymentMethods.TWINT,
            Enums.PaymentPagePaymentMethods.VISA,
            Enums.PaymentPagePaymentMethods.BLIK,
            Enums.PaymentPagePaymentMethods.WECHATPAY,
            Enums.PaymentPagePaymentMethods.POSTFINANCEPAY,
            Enums.PaymentPagePaymentMethods.PAYPAL };

        request.Notification = new Models.Core.Notification();
        request.Notification.SuccessNotifyUrl = url + "&res=success";
        request.Notification.FailNotifyUrl = url + "&res=fail";

        Console.WriteLine("Payment Page Request : ", color.Gray);
        Console.WriteLine(request.Json(), color.Yellow);
        Console.WriteLine("Posting ...", color.Gray);


        var result = await payment.InitializeAsync(request);
        Console.WriteLine("Post Request : ", color.Gray);
        Console.WriteLine(request.Json(), color.Yellow);
        Console.WriteLine("Post Results : ", color.Gray);
        Console.WriteLine(result.ToString(), color.Green);
        if (result.IsSuccess && !string.IsNullOrEmpty(result.Token) && !string.IsNullOrEmpty(result.RedirectUrl))
        {
            // Do Stuff
            CurrentTokens.Add(uid, result.Token);
            Console.WriteLine($"Redirecting to url [${result.RedirectUrl}] ...");
            Process.Start(new ProcessStartInfo
            {
                FileName = result.RedirectUrl,
                UseShellExecute = true
            });
        }
        else
        {
            Console.WriteLine("PaymentPageInitialize Error!", color.Red);
            Console.WriteLine(result.Error.ToString());
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        PaymentPage();

    }

    /// <summary>
    /// Assert Capture
    /// </summary>
    /// <param name="captureID"></param>
    public async static void AssertCapture(string captureID)
    {
        if (string.IsNullOrEmpty(captureID))
        {
            Console.Clear();
            Console.WriteLine("CaptureID is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Assert Capture ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.AssertCaptureAsync(new AssertCaptureRequest(captureID));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Multi Part Finalize
    /// </summary>
    /// <param name="trnId"></param>
    public async static void MultiPartFinalize(string trnId)
    {
        if (string.IsNullOrEmpty(trnId))
        {
            Console.Clear();
            Console.WriteLine("Transaction ID is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Multi Part Finalize ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.MultipartFinalizeAsync(new Models.Transaction.MultipartFinalizeRequest(trnId));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Inquiry
    /// </summary>
    /// <param name="trnId"></param>
    public async static void Inquiry(string trnId)
    {
        if (string.IsNullOrEmpty(trnId))
        {
            Console.Clear();
            Console.WriteLine("Transaction ID is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Inquiry ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.InquireAsync(new Models.Transaction.InquireRequest(trnId));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Cancel
    /// </summary>
    /// <param name="trnId"></param>
    public async static void Cancel(string trnId)
    {
        if (string.IsNullOrEmpty(trnId))
        {
            Console.Clear();
            Console.WriteLine("Transaction ID is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Cancel ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.CancelAsync(new Models.Transaction.CancelRequest(trnId));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Capture
    /// </summary>
    /// <param name="trnId"></param>
    public async static void Capture(string trnId)
    {
        if (string.IsNullOrEmpty(trnId))
        {
            Console.Clear();
            Console.WriteLine("Transaction ID is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Capture ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.CaptureAsync(new CaptureRequest(trnId));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Authorize Transaction
    /// </summary>
    /// <param name="token"></param>
    public async static void Authorize(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            Console.Clear();
            Console.WriteLine("Token is null!", color.Red);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...", color.Gray);
            Console.ReadLine();
            TransactionPage();
            return;
        }

        Console.Clear();
        Console.WriteLine("*** Authorize ...", color.Gray);
        var payment = SaferPayClient.Transaction;
        var response = await payment.AuthorizeAsync(new Models.Transaction.AuthorizeRequest(token));

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(response.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();
    }

    /// <summary>
    /// Initialize
    /// </summary>
    /// <param name="useTestCard"></param>
    /// <param name="onlyInit"></param>
    public async static void InitializeTransaction(string amount = "10000", bool useTestCard = true, string onlyInit = "")
    {
        Console.Clear();
        Console.WriteLine("*** Initializigin Transaction ...", color.Gray);
        var transaction = SaferPayClient.Transaction;
        var request = new SaferPay.Models.Transaction.InitializeRequest();

        var uid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        var url = $"{TestConfig.WebPage}transaction?orderId={uid}";
        if (!string.IsNullOrEmpty(onlyInit))
        {
            url = url + "&only=" + onlyInit;
        }

        request.TerminalId = TestConfig.TerminalId;
        request.ReturnUrl = url;
        request.Payment = new Payment();
        request.Payment.Amount = new Amount();
        request.Payment.Amount.CurrencyCode = TestConfig.Currency;
        request.Payment.Amount.Value = amount;
        request.Payment.Description = "Test Product";
        request.Payment.OrderId = uid;
        request.Payment.PayerNote = "Test Notes For Payer";

        request.Notification = new Models.Core.Notification();
        request.Notification.SuccessNotifyUrl = url + "&res=success";
        request.Notification.FailNotifyUrl = url + "&res=fail";

        TestCard card = TestConfig.Cards.FirstOrDefault();
        if (card != null && useTestCard)
        {
            request.PaymentMeans = new PaymentMeans();
            request.PaymentMeans.Card = new Card(card.Number, int.Parse(card.Expire.Substring(0, 2)), int.Parse(card.Expire.Substring(2, 2)), card.CVV, card.CardHolder);
        }


        Console.WriteLine("Initialize Request : ", color.Gray);
        Console.WriteLine(request.Json(), color.Yellow);
        Console.WriteLine("Posting ...", color.Gray);


        var result = await transaction.InitializeAsync(request);
        Console.WriteLine("Post Request : ", color.Gray);
        Console.WriteLine(request.Json(), color.Yellow);
        Console.WriteLine("Post Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        if (result.IsSuccess && !string.IsNullOrEmpty(result.Token) && result.Redirect != null)
        {
            // Do Stuff
            CurrentTokens.Add(uid, result.Token);
            Console.WriteLine($"Redirecting to url [${result.Redirect.RedirectUrl}] ...");
            Process.Start(new ProcessStartInfo
            {
                FileName = result.Redirect.RedirectUrl.ToString(),
                UseShellExecute = true
            });
        }
        else
        {
            Console.WriteLine("PaymentPageInitialize Error!", color.Red);
            Console.WriteLine(result.Error.ToString());
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();
        TransactionPage();

    }

    #region ManagementApi

    /// <summary>
    /// This method is used to retrieve the current license configuration for a customer
    /// </summary>
    public async static void LicensingCustomerLicense()
    {
        Console.Clear();
        Console.WriteLine("*** Licensing CustomerLicense ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine("Rest Calling ...", color.Gray);

        var result = await managementApi.LicensingCustomerLicenseAsync();
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();

    }

    /// <summary>
    /// This method is used to retrieve the current license configuration for a customer
    /// </summary>
    [Obsolete("DEPRECATED: since Version 1.35. Please use instead: /rest/customers/{customerId}/license")]
    public async static void LicensingCustomerLicenseConfiguration()
    {
        Console.Clear();
        Console.WriteLine("*** Licensing CustomerLicense Configuration ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine("Rest Calling ...", color.Gray);

        var result = await managementApi.LicensingCustomerLicenseConfigurationAsync();
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();

    }

    /// <summary>
    /// This method is used to retrieve details of one terminal
    /// </summary>
    public async static void TerminalGetTerminal()
    {
        Console.Clear();
        Console.WriteLine("*** Terminals GetTerminal ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine("Rest Calling ...", color.Gray);

        var result = await managementApi.TerminalGetTerminalAsync();
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();

    }

    /// <summary>
    /// This method is used to retrieve all terminals
    /// </summary>
    public async static void TerminalsGetTerminals()
    {
        Console.Clear();
        Console.WriteLine("*** Terminals GetTerminals ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine("Rest Calling ...", color.Gray);

        var result = await managementApi.TerminalsGetTerminalsAsync();
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();

    }


    /// <summary>
    /// This method is used to retrieve all terminals
    /// </summary>
    public async static void PaymentPageConfigGetConfigurations()
    {
        Console.Clear();
        Console.WriteLine("*** Payment Page Config Get Configurations ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine("Rest Calling ...", color.Gray);

        var result = await managementApi.PaymentPageConfigGetConfigurationsAsync();
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();

    }


    /// <summary>
    /// This function may be used to fetch the status of a previously created single use payment link
    /// </summary>
    public async static void SecurePayGateSingleUsePaymentLink()
    {
        Console.Clear();
        Console.WriteLine("*** Secure Pay Gate Single Use Payment Link ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine();
        Console.WriteLine();
        Console.Write(" Please enter offer Id : ", color.Yellow);
        var offerId = Console.ReadLine();

        Console.WriteLine("Rest Calling ...", color.Gray);

        var result = await managementApi.SecurePayGateSingleUsePaymentLinkAsync(offerId);
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();

    }


    public async static void SaferpayFieldsAccessTokenCreateAccessToken()
    {
        Console.Clear();
        Console.WriteLine("*** Saferpay Fields Access Token Create Access Token ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine();
        Console.WriteLine();
        Console.Write(" Please enter description for access token : ", color.Yellow);
        var desc = Console.ReadLine();

        Console.Write(" Please enter source urls seperated by comma (,) : ", color.Yellow);
        var sourceUrls = Console.ReadLine();
        var sourceUriList = new List<string>();

        if (string.IsNullOrEmpty(desc))
        {
            desc = "Dummy Test Description For Access Token";
        }

        if (string.IsNullOrEmpty(sourceUrls))
        {
            sourceUriList.Add("https://tools.multifonks.com/en/tools");
        }
        else
        {
            sourceUriList.AddRange(sourceUrls.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()));
        }

        var request = new CreateAccessTokenRequest()
        {
            Description = desc,
            SourceUrls = sourceUriList
        };

        Console.WriteLine("Post Request : ", color.Gray);
        Console.WriteLine(request.Json(), color.Yellow);

        Console.WriteLine("Post data ... : ", color.Gray);

        var resp = await managementApi.SaferpayFieldsAccessTokenCreateAccessTokenAsync(request);

        Console.WriteLine("Results : ", color.Gray);

        if (resp.IsSuccess)
        {
            Console.WriteLine(resp.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(resp.Json(), color.Red);
        }       

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();
    }


    /// <summary>
    /// This method may be used to delete a previously created Saferpay Fields Access Token.
    /// </summary>
    public async static void SaferpayFieldsAccessTokenDeleteAccessToken()
    {
        Console.Clear();
        Console.WriteLine("*** Saferpay Fields Access Token Delete Access Token ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine();
        Console.WriteLine();
        Console.Write(" Please enter access token : ", color.Yellow);
        var accessToken = Console.ReadLine();        

        if (string.IsNullOrEmpty(accessToken))
        {
            Console.WriteLine("Access Token Cannot Be Empty", color.Red);
            Console.ReadLine();
            ManagementApiPage();
            return;
        }

        var result = await managementApi.SaferpayFieldsAccessTokenDeleteAccessTokenAsync(accessToken);
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();
    }


    /// <summary>
    /// This method is used to retrieve a list of transactions based on the provided criteria.
    /// </summary>
    public async static void TransactionReportingGetTransactions()
    {
        Console.Clear();
        Console.WriteLine("*** Transaction Reporting Get Transactions ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine();
        Console.WriteLine();
        Console.Write(" Please enter start date (yyyy-MM-dd) : ", color.Yellow);
        var startDate = Console.ReadLine();
        if (!DateTime.TryParseExact(startDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedStartDate))
        {
            // make it default
            parsedStartDate = DateTime.Now.AddDays(-30);
        }

        Console.WriteLine();
        Console.Write(" Please enter end date (yyyy-MM-dd) : ", color.Yellow);
        var endDate = Console.ReadLine();
        if (!DateTime.TryParseExact(endDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedEndDate))
        {
            // make it default
            parsedEndDate = DateTime.Now;
        }

        var request = new ReportingGetTransactionsRequest()
        {
            StartDate = parsedStartDate,
            EndDate = parsedEndDate
        };

        Console.WriteLine("Post Request : ", color.Gray);
        Console.WriteLine(request.Json(), color.Yellow);

        Console.WriteLine("Post data ... : ", color.Gray);

        var result = await managementApi.TransactionReportingGetTransactionsAsync(request);
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();
    }



    public async static void SecurePayGateCreateSingleUsePaymentLink()
    {
        Console.Clear();
        Console.WriteLine("*** Secure Pay Gate Create Single Use PaymentLink ...", color.Gray);
        var managementApi = SaferPayClient.ManagementApi;

        Console.WriteLine();
        Console.WriteLine();
        Console.Write(" Please enter expiration date (yyyy-MM-dd) : ", color.Yellow);
        var expirationDate = Console.ReadLine();
        if (!DateTime.TryParseExact(expirationDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedExpirationDate))
        {
            // make it default
            parsedExpirationDate = DateTime.Now.AddDays(30);
        }

        var uid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();

        var request = new CreateSingleUsePaymentLinkRequest()
        {
            ExpirationDate = parsedExpirationDate,
            Payer = new Models.Core.Payer()
            {
                LanguageCode = Enums.Languages.English,
                BillingAddress = new Models.Core.PayerAddress()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Company = "Saferpay AG",
                    Gender = Enums.GenderTypes.MALE,
                    Email = "info@viwo.com.tr",
                    City = "Zurich",
                    CountryCode = "CH",
                    Street = "Bahnhofstrasse",
                    Zip = "8001"
                },
            }
        };

        request.Payment = new Models.Core.Payment();
        request.Payment.Amount = new Models.Core.Amount(100, TestConfig.Currency);
        request.Payment.Description = "Test Product";
        request.Payment.OrderId = uid;
        request.Payment.PayerNote = "Test Notes For Payer";
        request.Payment.Options = new PaymentOptions
        {
            PreAuth = true
        };

        Console.WriteLine("Post Request : ", color.Gray);
        Console.WriteLine(request.Json(), color.Yellow);

        Console.WriteLine("Post data ... : ", color.Gray);

        var result = await managementApi.SecurePayGateCreateSingleUsePaymentLinkAsync(request);
        Console.WriteLine("Results : ", color.Gray);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Json(), color.Green);
        }
        else
        {
            Console.WriteLine(result.Json(), color.Red);
        }

        Console.WriteLine();
        Console.WriteLine("Press a key to continue ...", color.Gray);
        Console.ReadLine();

        ManagementApiPage();
    }
    #endregion



}
