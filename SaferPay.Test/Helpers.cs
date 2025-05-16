using SaferPay.Extensions;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Transaction;
using System.Diagnostics;
using System.Drawing;
using color = System.Drawing.Color;
using Console = Colorful.Console;

namespace SaferPay.Test
{
    public static class Helpers
    {

        public static ISaferPayClient SaferPayClient;

        public static Dictionary<string, string> CurrentTokens = new Dictionary<string, string>();

        public static void CreateClient()
        {
            SaferPayClient = new SaferPayClient(TestConfig.CustomerId, TestConfig.TerminalId, TestConfig.ApiUserName, TestConfig.ApiPassword, true);
        }

        public enum Interfaces
        {
            Interfaces,
            PaymentPage,
            Transaction,
            SecureCardData,
            Batch,
            OmniChannel,
            ProcessCommand
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
            Console.WriteLine();
            Console.WriteLine(" 6. Show Tokens");
            Console.WriteLine(" 7. Json Converter");
            Console.WriteLine(" 8. Exit");
            Console.WriteLine();
            Console.WriteLine(" Please select an option ...");

            PrintCursor();

            var option = Console.ReadLine();
            int optionID = 0;

            if (int.TryParse(option, out optionID) && optionID > 0 && optionID <= 7)
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

                    case 7:
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

                    case 8:
                        ExitConsole = true;
                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please select an option between 1 and 7 !", color.Red);

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

    }
}
