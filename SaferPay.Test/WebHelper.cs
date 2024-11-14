using SaferPay.Models.Transaction;
using System.Net;
using color = System.Drawing.Color;
using Console = Colorful.Console;

namespace SaferPay.Test;

public static class WebHelper
{
    public async static void InitWeb(string[] args)
    {
        using (var listener = new HttpListener())
        {
            listener.Prefixes.Add(TestConfig.WebPage);
            listener.Start();
            Console.WriteLine($" *** Listening for requests at {TestConfig.WebPage}", color.Green);

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                switch (request?.Url!.AbsolutePath)
                {
                    case "/payment-page":
                        await ProcessPaymentPage(request, response, context);
                        break;

                    case "/transaction":
                        await ProcessTransaction(request, response, context);
                        break;

                    default:
                        await ErrorResponse(response, "Error", "The page you entered is invalid! Pages will be triggered by SaferPay responses.");
                        break;
                }
            }
        }
    }


    public async static Task ProcessTransaction(HttpListenerRequest request, HttpListenerResponse response, HttpListenerContext context)
    {
        switch (request.HttpMethod)
        {
            case "GET":
                var orderId = request.QueryString["orderId"].ToString();
                var res = request.QueryString["res"];
                var only = request.QueryString["only"];


                if (string.IsNullOrEmpty(orderId) || !Helpers.CurrentTokens.ContainsKey(orderId))
                {
                    response.StatusCode = 404;
                    response.Close();
                    break;
                }

                var token = Helpers.CurrentTokens[orderId].ToString();
                var transaction = Helpers.SaferPayClient.Transaction;


                if (!string.IsNullOrEmpty(only) && only == "init")
                {
                    GenerateConsoleSuccess("[Transaction] Successfully Init Completed!", "");
                    await SuccessResponse(response, "Initialization Successful", $"Transaction initialization has been successfully completed. You can authorize the transaction using the following token: <b>{token}</b>");
                    break;
                }

                var result = await transaction.AuthorizeAsync(new Models.Transaction.AuthorizeRequest(token));
                if (result.IsSuccess && result != null && result.Transaction != null)
                {

                    if (!string.IsNullOrEmpty(only) && only == "auth")
                    {
                        GenerateConsoleSuccess("[Transaction] Successfully Auth Completed! Status : ", result.Transaction.Status.ToString());
                        string desc1 = $"Transaction Authorize has been successfully completed. The following Transaction Status is <b>{result.Transaction.Status.ToString()}</b>. You can capture the transaction using the following Transaction ID: <b>{result.Transaction.Id}</b>";
                        if (result.Transaction.Status != Enums.TransactionStatus.AUTHORIZED)
                        {
                            desc1 = $"Transaction Authorize has been successfully completed. The following Transaction Status is <b>{result.Transaction.Status.ToString()}</b>";
                        }
                        await SuccessResponse(response, "Authorize Successful", desc1);
                        break;
                    }

                    if (result.Transaction.Status != Enums.TransactionStatus.AUTHORIZED)
                    {
                        await GenerateConsoleErrorWithResponse(response, "[Transaction] Transaction Not Authorized, Current Status : ", result.Transaction.Status.ToString());
                        string desc1 = $"Transaction Authorize has been failed! The following Transaction Status is <b>{result.Transaction.Status.ToString()}</b>";
                        await ErrorResponse(response, "Authorize Failed!", desc1);
                        break;
                    }

                    // Capture Transaction
                    var capture = new CaptureRequest(result.Transaction.Id);

                    var trnRes = await transaction.CaptureAsync(capture);
                    if (!trnRes.IsSuccess)
                    {
                        await GenerateConsoleErrorWithResponse(response, "[Transaction] Capture Error : ", trnRes.Error.ToString());
                        string desc1 = $"Transaction Capture has been failed! Errors :  <b>{trnRes.Error.ToString()}</b>";
                        await ErrorResponse(response, "Capture Failed!", desc1);
                        break;
                    }

                    GenerateConsoleSuccess("[Transaction] Successfully Completed! CaptureID : ", trnRes.CaptureId);
                    await SuccessResponse(response, "Payment Successful", $"Your payment has been successfully completed. Capture ID : <b>{trnRes.CaptureId}</b>");
                    break;
                }
                else
                {
                    await GenerateConsoleErrorWithResponse(response, "[Transaction] Error : ", result.Error.ToString());
                    string desc1 = $"Transaction has been failed! Errors: <b>{result.Error.ToString()}</b>";
                    await ErrorResponse(response, "Transaction Failed!", desc1);
                    break;
                }

                break;

            default:
                break;
        }
    }

    public async static Task ProcessPaymentPage(HttpListenerRequest request, HttpListenerResponse response, HttpListenerContext context)
    {
        switch (request.HttpMethod)
        {
            case "GET":

                var orderId = request.QueryString["orderId"].ToString();
                var res = request.QueryString["res"];


                if (string.IsNullOrEmpty(orderId) || !Helpers.CurrentTokens.ContainsKey(orderId))
                {
                    response.StatusCode = 404;
                    response.Close();
                    break;
                }

                var token = Helpers.CurrentTokens[orderId].ToString();
                var payment = Helpers.SaferPayClient.PaymentPage;

                var result = await payment.AssertAsync(new SaferPay.Models.PaymentPage.AssertRequest(token));
                if (result.IsSuccess && result != null && result.Transaction != null)
                {

                    if (result.Transaction.Status != Enums.TransactionStatus.AUTHORIZED)
                    {
                        await GenerateConsoleErrorWithResponse(response, "[Transaction] Transaction Not Authorized, Current Status : ", result.Transaction.Status.ToString());
                        string desc1 = $"Transaction Authorize has been failed! The following Transaction Status is <b>{result.Transaction.Status.ToString()}</b>";
                        await ErrorResponse(response, "Authorize Failed!", desc1);
                        break;
                    }

                    // Capture Transaction
                    var trn = Helpers.SaferPayClient.Transaction;
                    var capture = new CaptureRequest(result.Transaction.Id);

                    var trnRes = await trn.CaptureAsync(capture);
                    if (!trnRes.IsSuccess)
                    {
                        await GenerateConsoleErrorWithResponse(response, "[Transaction] Capture Error : ", trnRes.Error.ToString());
                        string desc1 = $"Transaction Capture has been failed! Errors :  <b>{trnRes.Error.ToString()}</b>";
                        await ErrorResponse(response, "Capture Failed!", desc1);
                        break;
                    }

                    GenerateConsoleSuccess("[PaymentPage] Successfully Completed! CaptureID : ", trnRes.CaptureId);
                    await SuccessResponse(response, "Payment Successful", $"Your payment has been successfully completed. Capture ID : <b>{trnRes.CaptureId}</b>");
                    break;
                }
                else
                {
                    await GenerateConsoleErrorWithResponse(response, "[Transaction] Error : ", result.Error.ToString());
                    string desc1 = $"Transaction has been failed! Errors: <b>{result.Error.ToString()}</b>";
                    await ErrorResponse(response, "Transaction Failed!", desc1);
                    break;
                }

            default:
                break;
        }
    }

    public static void GenerateConsoleError(string title, string message)
    {
        Console.WriteLine();
        Console.Write(title, color.Red);
        Console.WriteLine(message, color.Red);
    }

    public static void GenerateConsoleSuccess(string title, string message)
    {
        Console.WriteLine();
        Console.Write(title, color.Green);
        Console.WriteLine(message, color.Green);
    }

    public async static Task GenerateResponse(HttpListenerResponse response, string html)
    {
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);
        response.ContentLength64 = buffer.Length;
        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        response.Close();
    }

    public async static Task SuccessResponse(HttpListenerResponse response, string title, string desc)
    {
        var html = "";
        using (var reader = new StreamReader("success.html"))
        {
            html = reader.ReadToEnd();
        }

        html = html.Replace("{{Title}}", title).Replace("{{Desc}}", desc);
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);
        response.ContentLength64 = buffer.Length;
        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        response.Close();
    }

    public async static Task ErrorResponse(HttpListenerResponse response, string title, string desc)
    {
        var html = "";
        using (var reader = new StreamReader("failed.html"))
        {
            html = reader.ReadToEnd();
        }

        html = html.Replace("{{Title}}", title).Replace("{{Desc}}", desc);
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);
        response.ContentLength64 = buffer.Length;
        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        response.Close();
    }

    public async static Task GenerateConsoleErrorWithResponse(HttpListenerResponse response, string title, string message)
    {
        Console.WriteLine();
        Console.Write(title, color.Red);
        Console.WriteLine(message, color.Red);
    }
}
