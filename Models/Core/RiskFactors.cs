using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

/// <summary>
/// Optional risk factors
/// </summary>
/// <remarks> 
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks> 
public class RiskFactors
{
    /// <summary>
    /// Delivery method<br/><br/>
    /// <i>Possible values: EMAIL, SHOP, HOMEDELIVERY, PICKUP, HQ.</i>
    /// </summary>
    /// <value>The <c>DeliveryType</c> property represents <see langword="DeliveryTypes"/> enum.</value>
    /// <example>
    /// <code>EMAIL, SHOP, HOMEDELIVERY, PICKUP, HQ</code>
    /// </example>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DeliveryTypes DeliveryType { get; set; }


    /// <summary>
    /// The customer's Session ID (mastered by DFP Device Fingerprinting), or the event ID if the session is not available<br/><br/>
    /// <i>Max length: 1024</i>
    /// </summary>
    /// <example><code></code></example>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string DeviceFingerprintTransactionId { get; set; }


    /// <summary>
    /// Is the transaction B2B?
    /// </summary>
    /// <value><see langword="bool"/></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool IsB2B { get; set; }


    /// <summary>
    /// Information on the payer executing the transaction, generally referring to his/her customer profile in the shop (if any).
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public PayerProfile PayerProfile { get; set; }


}
