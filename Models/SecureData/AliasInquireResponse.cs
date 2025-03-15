using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData;

public class AliasInquireResponse : ResponseBase
{
    /// <summary>
    /// Information about the registered alias.
    /// </summary>
    public Alias Alias { get; set; }

    /// <summary>
    /// Result of the Check
    /// </summary>
    public CheckResult CheckResult { get; set; }

    /// <summary>
    /// Information about the registered means of payment
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }

    /// <summary>
    /// result of external tokenization
    /// </summary>
    public Tokenization Tokenization { get; set; }
}
