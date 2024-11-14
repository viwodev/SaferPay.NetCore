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

    [Description("Bonus")]
    BONUS,

    [Description("Diners Club International & Discover Card")]
    DINERS,

    [Description("SEPA Direct Debit")]
    DIRECTDEBIT,

    [Description("e-przelewy")]
    EPRZELEWY,

    [Description("eps")]
    EPS,

    [Description("giropay")]
    GIROPAY,

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

    [Description("MyOne")]
    MYONE,

    [Description("PayConiq")]
    PAYCONIQ,

    [Description("paydirekt")]
    PAYDIREKT,

    [Description("PayPal")]
    PAYPAL,

    [Description("PostCard")]
    POSTCARD,

    [Description("Postfinance Card & eFinance")]
    POSTFINANCE,

    [Description("Sofort by Klarna")]
    SOFORT,

    [Description("TWINT")]
    TWINT,

    [Description("UnionPay")]
    UNIONPAY,

    [Description("Visa & V PAY")]
    VISA,

    [Description("WL Crypto Payments")]
    WLCRYPTOPAYMENTS,

    [Description("WECHATPAY")]
    WECHATPAY
}
