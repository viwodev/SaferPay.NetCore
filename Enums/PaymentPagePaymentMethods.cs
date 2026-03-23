using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

/// <summary>
/// V: 1.51 (Removed INVOICE from PaymentMethods)<br/><br/>
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum PaymentPagePaymentMethods
{
    ACCOUNTTOACCOUNT,
    ALIPAY,
    AMEX,
    BANCONTACT,
    BLIK,
    DINERS,
    CARD,
    DIRECTDEBIT,
    EPRZELEWY,
    EPS,
    GIROPAY,
    IDEAL,
    JCB,
    KLARNA,
    MAESTRO,
    MASTERCARD,
    PAYCONIQ,
    PAYDIREKT,
    PAYPAL,
    POSTFINANCEPAY,
    REKA,
    SOFORT,
    TWINT,
    UNIONPAY,
    VISA,
    WECHATPAY,
    WLCRYPTOPAYMENTS
}
