using SaferPay.Models.Core;

namespace SaferPay.Models.OmniChannel;

/// <summary>
/// AcquireTransaction
/// </summary>
public class AcquireTransactionResponse : ResponseBase
{
    /// <summary>
    /// Dcc information, if applicable
    /// </summary>
    public Dcc Dcc { get; set; }

    /// <summary>
    /// Information about the means of payment
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }

    /// <summary>
    /// Information about the transaction
    /// </summary>
    public TransactionItem Transaction { get; set; }

}
