using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum OrderItemTypes
    {
        DIGITAL, 
        PHYSICAL, 
        SERVICE, 
        GIFTCARD, 
        DISCOUNT, 
        SHIPPINGFEE, 
        SALESTAX, 
        SURCHARGE
    }
}
