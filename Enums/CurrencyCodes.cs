using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum CurrencyCodes
{
    [Description("Australian Dollar")]
    AUD,

    [Description("Brazilian Real")]
    BRL,

    [Description("British Pound")]
    GBP,

    [Description("Bulgarian Lev")]
    BGN,

    [Description("Canadian Dollar")]
    CAD,

    [Description("Swiss Franc")]
    CHF,

    [Description("Chinese Yuan")]
    CNY,

    [Description("Czech Koruna")]
    CZK,

    [Description("Danish Krone")]
    DKK,

    [Description("Egyptian Pound")]
    EGP,

    [Description("Euro")]
    EUR,

    [Description("Hong Kong Dollar")]
    HKD,

    [Description("Croatian Kuna")]
    HRK,

    [Description("Hungarian Forint")]
    HUF,

    [Description("Indonesian Rupiah")]
    IDR,

    [Description("Israeli New Shekel")]
    ILS,

    [Description("Indian Rupee")]
    INR,

    [Description("Icelandic Króna")]
    ISK,

    [Description("Japanese Yen")]
    JPY,

    [Description("South Korean Won")]
    KRW,

    [Description("Kuwaiti Dinar")]
    KWD,

    [Description("Kazakhstani Tenge")]
    KZT,

    [Description("Mexican Peso")]
    MXN,

    [Description("Malaysian Ringgit")]
    MYR,

    [Description("Norwegian Krone")]
    NOK,

    [Description("New Zealand Dollar")]
    NZD,

    [Description("Philippine Peso")]
    PHP,

    [Description("Polish Zloty")]
    PLN,

    [Description("Qatari Riyal")]
    QAR,

    [Description("Romanian Leu")]
    RON,

    [Description("Russian Ruble")]
    RUB,

    [Description("Saudi Riyal")]
    SAR,

    [Description("Swedish Krona")]
    SEK,

    [Description("Singapore Dollar")]
    SGD,

    [Description("Thai Baht")]
    THB,

    [Description("Turkish Lira")]
    TRY,

    [Description("Taiwan Dollar")]
    TWD,

    [Description("Ukrainian Hryvnia")]
    UAH,

    [Description("United Arab Emirates Dirham")]
    AED,

    [Description("United States Dollar")]
    USD,

    [Description("Vietnamese Dong")]
    VND,

    [Description("South African Rand")]
    ZAR,

    [Description("Argentine Peso")]
    ARS,

    [Description("Bangladeshi Taka")]
    BDT,

    [Description("Colombian Peso")]
    COP,

    [Description("Chilean Peso")]
    CLP,

    [Description("Pakistani Rupee")]
    PKR,

    [Description("Sri Lankan Rupee")]
    LKR,

    [Description("Serbian Dinar")]
    RSD
}

