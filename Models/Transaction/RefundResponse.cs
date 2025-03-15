using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class RefundResponse : ResponseBase
{

    /// <summary>
    /// Dcc information, if applicable
    /// </summary>
    public Dcc Dcc { get; set; }


    /// <summary>
    /// Information about the means of payment
    /// </summary>
    public AuthorizationPaymentMeans PaymentMeans { get; set; }


    /// <summary>
    /// Information about the transaction
    /// </summary>
    public TransactionItem Transaction { get; set; }



    
}