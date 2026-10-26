using Newtonsoft.Json;
using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class Klarna
{
    /// <summary>
    /// Klarna extra merchant data (EMD).<br/><br/>
    /// <i>Check Klarna's EMD documentation for further details.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Attachment Attachment { get; set; }

    /// <summary>
    /// The company responsible for the shipping.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ShippingCarrier { get; set; }

    /// <summary>
    /// The type of shipping selected for this order. If not set, the default will be 'TO_DOOR'.<br/><br/>
    /// <i>Possible values: TO_DOOR, TO_CURB, TO_MAILBOX, PICKUP_BOX, PICKUP_POINT, PICKUP_STORE, PICKUP_WAREHOUSE, DIGITAL_DOWNLOAD, DIGITAL_OTHER, PHYSICAL_OTHER.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public KlarnaShippingTypes? ShippingType { get; set; }

    /// <summary>
    /// Additional service/attribute to the shipping type.<br/><br/>
    /// <i>Possible values: SIGNATURE_REQUIRED, IDENTIFICATION_REQUIRED, CONTACTLESS_DELIVERY, LEAVE_AT_DOOR, LEAVE_AT_CURB, LEAVE_WITH_NEIGHBOUR, EXPRESS, TRACKED, UNTRACKED.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public KlarnaShippingTypeAttributes? ShippingTypeAttribute { get; set; }
}
