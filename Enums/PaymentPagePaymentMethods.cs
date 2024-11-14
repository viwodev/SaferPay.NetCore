using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

/// <summary>
/// V: 1.43
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum PaymentPagePaymentMethods
{
    ACCOUNTTOACCOUNT,
    ALIPAY,
    AMEX,
    BANCONTACT,
    BLIK,
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
    POSTFINANCEPAY,
    SOFORT,
    TWINT,
    UNIONPAY,
    VISA,
    WECHATPAY,
    WLCRYPTOPAYMENTS
}
