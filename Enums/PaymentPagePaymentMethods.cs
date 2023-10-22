using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentPagePaymentMethods
    {
        ACCOUNTTOACCOUNT,
        ALIPAY,
        AMEX,
        BANCONTACT,
        BONUS,
        DINERS,
        CARD,
        DIRECTDEBIT,
        EPRZELEWY,
        EPS,
        GIROPAY,
        IDEAL,
        INVOICE,
        JCB,
        KLARNA,
        MAESTRO,
        MASTERCARD,
        MYONE,
        PAYCONIQ,
        PAYDIREKT,
        PAYPAL,
        POSTCARD,
        POSTFINANCE,
        SOFORT,
        TWINT,
        UNIONPAY,
        VISA,
        WLCRYPTOPAYMENTS
    }
}
