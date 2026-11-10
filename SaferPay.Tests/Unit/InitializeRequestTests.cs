using Newtonsoft.Json.Linq;
using SaferPay.Models.Core;
using SaferPay.Models.Transaction;

namespace SaferPay.Tests.Unit;

public class InitializeRequestTests
{
    [Fact]
    public void Ctor_PopulatesPaymentAndReturnUrl()
    {
        var req = new InitializeRequest("term-1", 12.34m, "CHF", "order-42", "https://shop/return");

        req.TerminalId.Should().Be("term-1");
        req.Payment.Should().NotBeNull();
        req.Payment.Amount.Value.Should().Be("1234");
        req.Payment.Amount.CurrencyCode.Should().Be("CHF");
        req.Payment.OrderId.Should().Be("order-42");

        req.ReturnUrl.Should().NotBeNull();
        req.ReturnUrl.Url.Should().Be(new Uri("https://shop/return"));
    }

    [Fact]
    public void SetCard_AttachesPaymentMeans()
    {
        var req = new InitializeRequest("term", 1m, "EUR", "o", "https://x/r")
            .SetCard("4242424242424242", 9, 2030, "123", "John");

        req.PaymentMeans.Should().NotBeNull();
    }

    [Fact]
    public void Json_OmitsNullChannelOptions()
    {
        var req = new InitializeRequest("term", 1m, "CHF", "o", "https://x/r");
        var jo = JObject.Parse(req.Json());

        jo.ContainsKey("Authentication").Should().BeFalse();
        jo.ContainsKey("CardForm").Should().BeFalse();
        jo.ContainsKey("Dcc").Should().BeFalse();
        jo["TerminalId"]!.Value<string>().Should().Be("term");
    }

    // Since 1.54 the DccInquiry result can be passed to Transaction/Initialize
    [Fact]
    public void Json_IncludesDccReference_WhenSet()
    {
        var req = new InitializeRequest("term", 1m, "CHF", "o", "https://x/r")
        {
            Dcc = new Dcc { SelectedCurrencyCode = "EUR", Token = "dcc-token" }
        };

        var jo = JObject.Parse(req.Json());

        jo["Dcc"]!["SelectedCurrencyCode"]!.Value<string>().Should().Be("EUR");
        jo["Dcc"]!["Token"]!.Value<string>().Should().Be("dcc-token");
    }

    // Since 1.55 Klarna network session data can be passed as PaymentMeans to Transaction/Initialize
    [Fact]
    public void Json_IncludesKlarnaPaymentMeans_WhenSet()
    {
        var req = new InitializeRequest("term", 1m, "CHF", "o", "https://x/r")
        {
            PaymentMeans = new KlarnaPaymentMeans("session-token")
        };

        var klarna = JObject.Parse(req.Json())["PaymentMeans"]!["Klarna"]!;

        klarna["KlarnaNetworkSessionToken"]!.Value<string>().Should().Be("session-token");
        ((JObject)klarna).ContainsKey("KlarnaNetworkData").Should().BeFalse();
    }
}
