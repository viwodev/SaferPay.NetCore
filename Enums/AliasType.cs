using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum AliasType
    {
        CARD,
        BANK_ACCOUNT,
        POSTFINANCE,
        TWINT
    }
}
