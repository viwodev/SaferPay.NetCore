using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum BlockReasonTypes
    {
        BLACKLIST_IP, 
        BLACKLIST_IP_ORIGIN, 
        BLACKLIST_PAYMENT_MEANS, 
        BLACKLIST_PAYMENT_MEANS_ORIGIN
    }
}
