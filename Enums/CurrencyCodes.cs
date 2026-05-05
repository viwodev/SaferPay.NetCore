using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum CurrencyCodes
{
    [Description("United Arab Emirates Dirham")]
    AED,

    [Description("Afghani")]
    AFN,

    [Description("Albanian Lek")]
    ALL,

    [Description("Armenian Dram")]
    AMD,

    [Description("Angolan Kwanza")]
    AOA,

    [Description("Argentine Peso")]
    ARS,

    [Description("Australian Dollar")]
    AUD,

    [Description("Aruban Florin")]
    AWG,

    [Description("Azerbaijani Manat")]
    AZN,

    [Description("Bosnia and Herzegovina Convertible Mark")]
    BAM,

    [Description("Barbados Dollar")]
    BBD,

    [Description("Bangladeshi Taka")]
    BDT,

    [Description("Bulgarian Lev")]
    BGN,

    [Description("Bahraini Dinar")]
    BHD,

    [Description("Burundian Franc")]
    BIF,

    [Description("Bermudian Dollar")]
    BMD,

    [Description("Brunei Dollar")]
    BND,

    [Description("Bolivian Boliviano")]
    BOB,

    [Description("Bolivian Mvdol")]
    BOV,

    [Description("Brazilian Real")]
    BRL,

    [Description("Bahamian Dollar")]
    BSD,

    [Description("Ngultrum")]
    BTN,

    [Description("Botswana Pula")]
    BWP,

    [Description("Belarusian Ruble")]
    BYN,

    [Description("Belize Dollar")]
    BZD,

    [Description("Canadian Dollar")]
    CAD,

    [Description("Congolese Franc")]
    CDF,

    [Description("Swiss Franc")]
    CHF,

    [Description("WIR Franc")]
    CHW,

    [Description("Unidad de Fomento")]
    CLF,

    [Description("Chilean Peso")]
    CLP,

    [Description("Chinese Yuan")]
    CNY,

    [Description("Colombian Peso")]
    COP,

    [Description("Unidad de Valor Real")]
    COU,

    [Description("Costa Rican Colón")]
    CRC,

    [Description("Cuban Peso")]
    CUP,

    [Description("Cabo Verde Escudo")]
    CVE,

    [Description("Czech Koruna")]
    CZK,

    [Description("Djibouti Franc")]
    DJF,

    [Description("Danish Krone")]
    DKK,

    [Description("Dominican Peso")]
    DOP,

    [Description("Algerian Dinar")]
    DZD,

    [Description("Egyptian Pound")]
    EGP,

    [Description("Nakfa")]
    ERN,

    [Description("Ethiopian Birr")]
    ETB,

    [Description("Euro")]
    EUR,

    [Description("Fijian Dollar")]
    FJD,

    [Description("Falkland Islands Pound")]
    FKP,

    [Description("British Pound")]
    GBP,

    [Description("Georgian Lari")]
    GEL,

    [Description("Ghanaian Cedi")]
    GHS,

    [Description("Gibraltar Pound")]
    GIP,

    [Description("Gambian Dalasi")]
    GMD,

    [Description("Guinean Franc")]
    GNF,

    [Description("Guatemalan Quetzal")]
    GTQ,

    [Description("Guyana Dollar")]
    GYD,

    [Description("Hong Kong Dollar")]
    HKD,

    [Description("Lempira")]
    HNL,

    [Description("Croatian Kuna")]
    HRK,

    [Description("Gourde")]
    HTG,

    [Description("Hungarian Forint")]
    HUF,

    [Description("Indonesian Rupiah")]
    IDR,

    [Description("Israeli New Shekel")]
    ILS,

    [Description("Indian Rupee")]
    INR,

    [Description("Iraqi Dinar")]
    IQD,

    [Description("Iranian Rial")]
    IRR,

    [Description("Icelandic Króna")]
    ISK,

    [Description("Jamaican Dollar")]
    JMD,

    [Description("Jordanian Dinar")]
    JOD,

    [Description("Japanese Yen")]
    JPY,

    [Description("Kenyan Shilling")]
    KES,

    [Description("Som")]
    KGS,

    [Description("Riel")]
    KHR,

    [Description("Comorian Franc")]
    KMF,

    [Description("North Korean Won")]
    KPW,

    [Description("South Korean Won")]
    KRW,

    [Description("Kuwaiti Dinar")]
    KWD,

    [Description("Cayman Islands Dollar")]
    KYD,

    [Description("Kazakhstani Tenge")]
    KZT,

    [Description("Lao Kip")]
    LAK,

    [Description("Lebanese Pound")]
    LBP,

    [Description("Sri Lankan Rupee")]
    LKR,

    [Description("Liberian Dollar")]
    LRD,

    [Description("Loti")]
    LSL,

    [Description("Libyan Dinar")]
    LYD,

    [Description("Moroccan Dirham")]
    MAD,

    [Description("Moldovan Leu")]
    MDL,

    [Description("Malagasy Ariary")]
    MGA,

    [Description("Macedonian Denar")]
    MKD,

    [Description("Tugrik")]
    MNT,

    [Description("Pataca")]
    MOP,

    [Description("Mauritian Rupee")]
    MUR,

    [Description("Rufiyaa")]
    MVR,

    [Description("Malawi Kwacha")]
    MWK,

    [Description("Mexican Peso")]
    MXN,

    [Description("Mexican Unidad de Inversion (UDI)")]
    MXV,

    [Description("Malaysian Ringgit")]
    MYR,

    [Description("Mozambique Metical")]
    MZN,

    [Description("Namibia Dollar")]
    NAD,

    [Description("Nigerian Naira")]
    NGN,

    [Description("Cordoba Oro")]
    NIO,

    [Description("Norwegian Krone")]
    NOK,

    [Description("Nepalese Rupee")]
    NPR,

    [Description("New Zealand Dollar")]
    NZD,

    [Description("Omani Rial")]
    OMR,

    [Description("Panamanian Balboa")]
    PAB,

    [Description("Peruvian Sol")]
    PEN,

    [Description("Kina")]
    PGK,

    [Description("Philippine Peso")]
    PHP,

    [Description("Pakistani Rupee")]
    PKR,

    [Description("Polish Zloty")]
    PLN,

    [Description("Paraguayan Guarani")]
    PYG,

    [Description("Qatari Riyal")]
    QAR,

    [Description("Romanian Leu")]
    RON,

    [Description("Serbian Dinar")]
    RSD,

    [Description("Russian Ruble")]
    RUB,

    [Description("Rwanda Franc")]
    RWF,

    [Description("Saudi Riyal")]
    SAR,

    [Description("Solomon Islands Dollar")]
    SBD,

    [Description("Seychelles Rupee")]
    SCR,

    [Description("Sudanese Pound")]
    SDG,

    [Description("Swedish Krona")]
    SEK,

    [Description("Singapore Dollar")]
    SGD,

    [Description("Saint Helena Pound")]
    SHP,

    [Description("Leone")]
    SLL,

    [Description("Somali Shilling")]
    SOS,

    [Description("Surinam Dollar")]
    SRD,

    [Description("El Salvador Colon")]
    SVC,

    [Description("Syrian Pound")]
    SYP,

    [Description("Lilangeni")]
    SZL,

    [Description("Thai Baht")]
    THB,

    [Description("Somoni")]
    TJS,

    [Description("Tunisian Dinar")]
    TND,

    [Description("Pa’anga")]
    TOP,

    [Description("Turkish Lira")]
    TRY,

    [Description("Trinidad and Tobago Dollar")]
    TTD,

    [Description("Taiwan Dollar")]
    TWD,

    [Description("Tanzanian Shilling")]
    TZS,

    [Description("Ukrainian Hryvnia")]
    UAH,

    [Description("Uganda Shilling")]
    UGX,

    [Description("United States Dollar")]
    USD,

    [Description("US Dollar (Next day)")]
    USN,

    [Description("Uruguayan Peso")]
    UYU,

    [Description("Uzbekistani Som")]
    UZS,

    [Description("Bolívar")]
    VEF,

    [Description("Vietnamese Dong")]
    VND,

    [Description("Vatu")]
    VUV,

    [Description("Tala")]
    WST,

    [Description("Central African CFA Franc")]
    XAF,

    [Description("East Caribbean Dollar")]
    XCD,

    [Description("West African CFA Franc")]
    XOF,

    [Description("CFP Franc")]
    XPF,

    [Description("Yemeni Rial")]
    YER,

    [Description("South African Rand")]
    ZAR,

    [Description("Zimbabwe Dollar")]
    ZWL
}