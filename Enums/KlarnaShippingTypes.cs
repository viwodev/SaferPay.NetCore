using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

/// <summary>
/// V:1.54
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum KlarnaShippingTypes
{
    TO_DOOR,
    TO_CURB,
    TO_MAILBOX,
    PICKUP_BOX,
    PICKUP_POINT,
    PICKUP_STORE,
    PICKUP_WAREHOUSE,
    DIGITAL_DOWNLOAD,
    DIGITAL_OTHER,
    PHYSICAL_OTHER
}
