using Newtonsoft.Json.Linq;
using SaferPay.Models.Core;
using SaferPay.Models.Management;

namespace SaferPay.Tests.Unit;

public class CreateSingleUsePaymentLinkRequestTests
{
    // Payer.Id is accepted for single-use payment links since 1.54
    [Fact]
    public void Json_IncludesPayerId()
    {
        var req = new CreateSingleUsePaymentLinkRequest
        {
            Payer = new Payer { Id = "customer-uuid-42" }
        };

        var jo = JObject.Parse(req.Json());

        jo["Payer"]!["Id"]!.Value<string>().Should().Be("customer-uuid-42");
    }
}
