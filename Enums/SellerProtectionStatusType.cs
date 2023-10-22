using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{

    /// <summary>
    /// Seller protection status from PayPal.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum SellerProtectionStatusTypes
    {
        LIGIBLE, 
        PARTIALLY_ELIGIBLE, 
        NOT_ELIGIBLE
    }
}
