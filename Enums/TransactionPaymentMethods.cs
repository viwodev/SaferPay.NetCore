using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
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
}
