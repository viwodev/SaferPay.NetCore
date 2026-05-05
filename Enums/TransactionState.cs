using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum TransactionState
{
    NONE,
    SUCCESSFUL, 
    FAILED, 
    PENDING
}
