using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum ExemptionTypes
{
    LOW_VALUE,
    TRANSACTION_RISK_ANALYSIS,
    RECURRING
}
