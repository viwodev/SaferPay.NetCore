using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class RefundDirectResponse : ResponseBase
{
    /// <summary>
    /// Information about the means of payment
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }


    /// <summary>
    /// Information about the transaction
    /// </summary>
    public TransactionItem Transaction { get; set; }
}
