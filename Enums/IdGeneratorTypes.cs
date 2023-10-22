using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum IdGeneratorTypes
    {
        MANUAL, 
        RANDOM, 
        RANDOM_UNIQUE
    }
}
