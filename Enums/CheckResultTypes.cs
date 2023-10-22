using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum CheckResultTypes
    {
        OK, 
        OK_AUTHENTICATED, 
        NOT_PERFORMED
    }
}
