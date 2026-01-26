using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class AlternativePaymentResponse : ResponseBase
{

    /// <summary>
    /// Contains details of a performed fraud prevention check
    /// </summary>
    public FraudPrevention FraudPrevention { get; set; }


    /// <summary>
    /// LiabilityShift information, replaces ThreeDs Info from api version 1.8
    /// </summary>
    public Liability Liability { get; set; }


    /// <summary>
    /// Information about the payer / card holder
    /// </summary>
    public Payer Payer { get; set; }


    /// <summary>
    /// Information about the means of payment
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }


    /// <summary>
    /// Information about the transaction
    /// </summary>
    public TransactionItem Transaction { get; set; }

}
