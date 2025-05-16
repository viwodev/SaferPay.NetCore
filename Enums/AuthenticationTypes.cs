using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum AuthenticationTypes
{
    STRONG_CUSTOMER_AUTHENTICATION,
    FRICTIONLESS,
    ATTEMPT,
    EXEMPTION,
    NONE
}
