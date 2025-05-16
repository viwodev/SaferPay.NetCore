using SaferPay.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(LanguageEnumConverter))]
public enum Languages
{
    [Description("bg")]
    Bulgarian,

    [Description("cs")]
    Czech,

    [Description("da")]
    Danish,

    [Description("de")]
    German,

    [Description("de-CH")]
    SwissGerman,

    [Description("el")]
    Greek,

    [Description("en")]
    English,

    [Description("es")]
    Spanish,

    [Description("et")]
    Estonian,

    [Description("fi")]
    Finnish,

    [Description("fr")]
    French,

    [Description("hr")]
    Croatian,

    [Description("hu")]
    Hungarian,

    [Description("is")]
    Icelandic,

    [Description("it")]
    Italian,

    [Description("ja")]
    Japanese,

    [Description("lt")]
    Lithuanian,

    [Description("lv")]
    Latvian,

    [Description("nl")]
    Dutch,

    [Description("nn")]
    Norwegian,

    [Description("pl")]
    Polish,

    [Description("pt")]
    Portuguese,

    [Description("ro")]
    Romanian,

    [Description("ru")]
    Russian,

    [Description("sk")]
    Slovak,

    [Description("sl")]
    Slovenian,

    [Description("sv")]
    Swedish,

    [Description("tr")]
    Turkish,

    [Description("uk")]
    Ukrainian,

    [Description("zh")]
    Chinese
}

