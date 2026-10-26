using Newtonsoft.Json.Linq;
using SaferPay.Enums;
using SaferPay.Models.Core;
using SaferPay.Models.PaymentPage;

namespace SaferPay.Tests.Unit;

/// <summary>
/// Wire-contract tests for the <see cref="Klarna"/> options (API 1.54):
/// EMD attachment is optional and the shipping fields are sent as strings.
/// </summary>
public class KlarnaTests
{
    private static JObject KlarnaJson(Klarna klarna)
    {
        var req = new InitializePaymentPageRequest
        {
            PaymentMethodsOptions = new PaymentMethodsOptions { Klarna = klarna }
        };

        return (JObject)JObject.Parse(req.Json())["PaymentMethodsOptions"]!["Klarna"]!;
    }

    [Fact]
    public void Json_OmitsUnsetFields()
    {
        var jo = KlarnaJson(new Klarna());

        jo.Properties().Should().BeEmpty();
    }

    [Fact]
    public void Json_SerializesShippingFields_AsStrings()
    {
        var jo = KlarnaJson(new Klarna
        {
            ShippingCarrier = "DHL",
            ShippingType = KlarnaShippingTypes.PICKUP_POINT,
            ShippingTypeAttribute = KlarnaShippingTypeAttributes.LEAVE_WITH_NEIGHBOUR
        });

        jo["ShippingCarrier"]!.Value<string>().Should().Be("DHL");
        jo["ShippingType"]!.Value<string>().Should().Be("PICKUP_POINT");
        jo["ShippingTypeAttribute"]!.Value<string>().Should().Be("LEAVE_WITH_NEIGHBOUR");
        jo.ContainsKey("Attachment").Should().BeFalse();
    }

    [Fact]
    public void Json_IncludesAttachment_WhenSet()
    {
        var jo = KlarnaJson(new Klarna
        {
            Attachment = new Attachment { ContentType = "application/vnd.klarna.internal.emd-v2+json", Body = "{}" }
        });

        jo["Attachment"]!["ContentType"]!.Value<string>().Should().Be("application/vnd.klarna.internal.emd-v2+json");
        jo["Attachment"]!["Body"]!.Value<string>().Should().Be("{}");
    }
}
