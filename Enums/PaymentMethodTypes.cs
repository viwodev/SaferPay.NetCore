using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum PaymentMethodTypes
{

    [Description("Account to Account")]
    ACCOUNTTOACCOUNT,

    [Description("AliPay")]
    ALIPAY,

    [Description("American Express")]
    AMEX,

    [Description("Bancontact")]
    BANCONTACT,

    [Description("Card")]
    CARD,

    [Description("Diners Club International & Discover Card")]
    DINERS,

    [Description("SEPA Direct Debit")]
    DIRECTDEBIT,

    [Description("e-przelewy")]
    EPRZELEWY,

    [Description("eps")]
    EPS,

    [Obsolete("The payment methods GIROPAY, PAYDIREKT, SOFORT and WLCRYPTOPAYMENTS are no longer supported w. V:1.49")]
    [Description("giropay")]
    GIROPAY,

    [Description("Gift Card")]
    GIFTCARD,

    [Description("iDEAL")]
    IDEAL,

    [Description("Invoice")]
    INVOICE,

    [Description("JCB")]
    JCB,

    [Description("Klarna Payments")]
    KLARNA,

    [Description("Maestro International")]
    MAESTRO,

    [Description("Mastercard")]
    MASTERCARD,

    [Description("PayConiq")]
    PAYCONIQ,

    [Obsolete("The payment methods GIROPAY, PAYDIREKT, SOFORT and WLCRYPTOPAYMENTS are no longer supported w. V:1.49")]
    [Description("paydirekt")]
    PAYDIREKT,

    [Description("PayPal")]
    PAYPAL,

    [Description("PostCard")]
    POSTCARD,

    [Description("Postfinance Card & eFinance")]
    POSTFINANCE,

    [Description("Reka")]
    REKA,

    [Obsolete("The payment methods GIROPAY, PAYDIREKT, SOFORT and WLCRYPTOPAYMENTS are no longer supported w. V:1.49")]
    [Description("Sofort by Klarna")]
    SOFORT,

    [Description("TWINT")]
    TWINT,

    [Description("UnionPay")]
    UNIONPAY,

    [Description("Visa & V PAY")]
    VISA,

    [Obsolete("The payment methods GIROPAY, PAYDIREKT, SOFORT and WLCRYPTOPAYMENTS are no longer supported w. V:1.49")]
    [Description("WL Crypto Payments")]
    WLCRYPTOPAYMENTS,

    [Description("WECHATPAY")]
    WECHATPAY,

    [Description("WERO")]
    WERO
}
