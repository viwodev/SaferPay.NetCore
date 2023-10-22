using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum SecurePayGateOfferTypes
    {
        OPEN, 
        PAID, 
        EXPIRED
    }
}
