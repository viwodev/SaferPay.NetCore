using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    /// <summary>
    /// The Segment of card holder. Only returned for Alias/AssertInsert, Alias/InsertDirect and Alias/Update calls if available.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum HolderSegmentTypes
    {
        UNSPECIFIED, 
        CONSUMER, 
        CORPORATE, 
        CORPORATE_AND_CONSUMER
    }

}
