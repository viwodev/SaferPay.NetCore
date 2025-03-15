using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData;

public class AliasUpdateRequest : RequestBase
{
    /// <summary>
    /// Update parameters
    /// </summary>
    public Alias UpdateAlias { get; set; }

    /// <summary>
    /// Means of payment to update
    /// </summary>
    public PaymentMeans UpdatePaymentMeans { get; set; }
}
