using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

/// <summary>
/// AMEX, BONUS, DINERS, DIRECTDEBIT, JCB, MAESTRO, MASTERCARD, MYONE, VISA
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum AliasPaymentMethods
{
    AMEX, 
    BONUS, 
    DINERS, 
    DIRECTDEBIT, 
    JCB, 
    MAESTRO, 
    MASTERCARD, 
    MYONE, 
    VISA
}
