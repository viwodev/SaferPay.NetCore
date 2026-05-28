using Newtonsoft.Json.Linq;
using SaferPay.Enums;
using SaferPay.Models.Core;
using SaferPay.Models.SecureData;

namespace SaferPay.Tests.Unit;

/// <summary>
/// Wire-contract tests for <see cref="AliasInsertRequest"/> serialization.
/// Locks in the fix where Lifetime / Check / PaymentMethods / LanguageCode
/// became nullable so Saferpay no longer rejects the default-0 enum values.
/// </summary>
public class AliasInsertRequestTests
{
    [Fact]
    public void Json_OmitsNullableFields_WhenUnset()
    {
        var req = new AliasInsertRequest
        {
            RegisterAlias = new RegisterAlias { IdGenerator = IdGeneratorTypes.RANDOM_UNIQUE },
            Type = AliasType.CARD,
            ReturnUrl = new ReturnUrl("https://shop/return"),
        };

        var jo = JObject.Parse(req.Json());

        jo.ContainsKey("Check").Should().BeFalse();
        jo.ContainsKey("PaymentMethods").Should().BeFalse();
        jo.ContainsKey("LanguageCode").Should().BeFalse();
        jo["RegisterAlias"]!["Lifetime"].Should().BeNull();
    }

    [Fact]
    public void Json_SerializesNullableFields_WhenSet()
    {
        var req = new AliasInsertRequest
        {
            RegisterAlias = new RegisterAlias
            {
                IdGenerator = IdGeneratorTypes.RANDOM_UNIQUE,
                Lifetime = 500,
            },
            Type = AliasType.CARD,
            ReturnUrl = new ReturnUrl("https://shop/return"),
            Check = CheckTypes.ONLINE,
            PaymentMethods = AliasPaymentMethods.VISA,
        };

        var jo = JObject.Parse(req.Json());

        jo["Check"]!.Value<string>().Should().Be("ONLINE");
        jo["PaymentMethods"]!.Value<string>().Should().Be("VISA");
        jo["RegisterAlias"]!["Lifetime"]!.Value<int>().Should().Be(500);
    }
}
