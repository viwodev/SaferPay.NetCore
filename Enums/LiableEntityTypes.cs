using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    /// <summary>
    /// Indicates who takes the liability for the transaction
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum LiableEntityTypes
    {
        MERCHANT,
        THREEDS
    }
}
