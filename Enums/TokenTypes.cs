using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum TokenTypes
{
    APPLEPAY, 
    GOOGLEPAY, 
    SAMSUNGPAY, 
    CLICKTOPAY, 
    OTHER, 
    MDES, 
    VTS
}
