using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

/// <summary>
/// V:1.54
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum KlarnaShippingTypeAttributes
{
    SIGNATURE_REQUIRED,
    IDENTIFICATION_REQUIRED,
    CONTACTLESS_DELIVERY,
    LEAVE_AT_DOOR,
    LEAVE_AT_CURB,
    LEAVE_WITH_NEIGHBOUR,
    EXPRESS,
    TRACKED,
    UNTRACKED
}
