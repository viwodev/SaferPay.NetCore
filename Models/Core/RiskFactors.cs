using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class RiskFactors
{
    /// <summary>
    /// Delivery method<br/><br/>
    /// <i>Possible values: EMAIL, SHOP, HOMEDELIVERY, PICKUP, HQ.</i>
    /// </summary>
    public DeliveryTypes DeliveryType { get; set; }

    /// <summary>
    /// The customer's Session ID (mastered by DFP Device Fingerprinting), or the event ID if the session is not available
    /// </summary>
    public string DeviceFingerprintTransactionId { get; set; }

    /// <summary>
    /// Is the transaction B2B?
    /// </summary>
    public bool IsB2B { get; set; }

    /// <summary>
    /// Information on the payer executing the transaction, generally referring to his/her customer profile in the shop (if any).
    /// </summary>
    public PayerProfile PayerProfile { get; set; }


}
