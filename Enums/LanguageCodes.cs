using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum LanguageCodes
    {
        /// <summary>
        /// Bulgarian
        /// </summary>
        [Description("Bulgarian")]
        bg,

        /// <summary>
        /// Czech
        /// </summary>
        [Description("Czech")]
        cs,

        /// <summary>
        /// Danish
        /// </summary>
        [Description("Danish")]
        da,

        /// <summary>
        /// German
        /// </summary>
        [Description("German")]
        de,

        /// <summary>
        /// Swiss German
        /// </summary>
        [Description("Swiss German")]
        de_ch,

        /// <summary>
        /// Greek
        /// </summary>
        [Description("Greek")]
        el,

        /// <summary>
        /// English
        /// </summary>
        [Description("English")]
        en,

        /// <summary>
        /// Spanish
        /// </summary>
        [Description("Spanish")]
        es,

        /// <summary>
        /// Estonian
        /// </summary>
        [Description("Estonian")]
        et,

        /// <summary>
        /// Finnish
        /// </summary>
        [Description("Finnish")]
        fi,

        /// <summary>
        /// French
        /// </summary>
        [Description("French")]
        fr,

        /// <summary>
        /// Croatian
        /// </summary>
        [Description("Croatian")]
        hr,

        /// <summary>
        /// Hungarian
        /// </summary>
        [Description("Hungarian")]
        hu,

        /// <summary>
        /// Icelandic
        /// </summary>
        [Description("Icelandic")]
        @is,

        /// <summary>
        /// Italian
        /// </summary>
        [Description("Italian")]
        it,

        /// <summary>
        /// Japanese
        /// </summary>
        [Description("Japanese")]
        ja,

        /// <summary>
        /// Lithuanian
        /// </summary>
        [Description("Lithuanian")]
        lt,

        /// <summary>
        /// Latvian
        /// </summary>
        [Description("Latvian")]
        lv,

        /// <summary>
        /// Dutch
        /// </summary>
        [Description("Dutch")]
        nl,

        /// <summary>
        /// Norwegian
        /// </summary>
        [Description("Norwegian")]
        nn,

        /// <summary>
        /// Polish
        /// </summary>
        [Description("Polish")]
        pl,

        /// <summary>
        /// Portuguese
        /// </summary>
        [Description("Portuguese")]
        pt,

        /// <summary>
        /// Romanian
        /// </summary>
        [Description("Romanian")]
        ro,

        /// <summary>
        /// Russian
        /// </summary>
        [Description("Russian")]
        ru,

        /// <summary>
        /// Slovak
        /// </summary>
        [Description("Slovak")]
        sk,

        /// <summary>
        /// Slovenian
        /// </summary>
        [Description("Slovenian")]
        sl,

        /// <summary>
        /// Swedish
        /// </summary>
        [Description("Swedish")]
        sv,

        /// <summary>
        /// Turkish
        /// </summary>
        [Description("Turkish")]
        tr,

        /// <summary>
        /// Ukrainian
        /// </summary>
        [Description("Ukrainian")]
        uk,

        /// <summary>
        /// Chinese
        /// </summary>
        [Description("Chinese")]
        zh
    }
}
