using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum AuthenticationResultTypes
    {
        OK,
        NOT_SUPPORTED
    }
}
