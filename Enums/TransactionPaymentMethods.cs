using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

/// <summary>
/// V:1.43
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum TransactionPaymentMethods
{
    AMEX,
    BANCONTACT,
    BONUS,
    DINERS,
    DIRECTDEBIT,
    JCB,
    MAESTRO,
    MASTERCARD,
    MYONE,
    VISA
}
