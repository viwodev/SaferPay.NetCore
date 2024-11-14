using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;

/// <summary>
/// V:1.43
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum WalletTypes
{
    [Description("Apple Pay")]
    APPLEPAY,

    [Description("Google Pay")]
    GOOGLEPAY,

    [Description("Click To Pay")]
    CLICKTOPAY
}
