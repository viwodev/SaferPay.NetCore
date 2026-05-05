using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;


[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum SecurePayGateOfferStatus
{
    [Description("Open")]
    OPEN,

    [Description("Paid")]
    PAID,

    [Description("Expired")]
    EXPIRED,

    [Description("Disabled")]
    DISABLED
}
