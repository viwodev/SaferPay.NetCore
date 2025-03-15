using SaferPay.Models.Core;
using SaferPay.Models.Mastercard;

namespace SaferPay.Models.Transaction;

public class AuthorizeDirectResponse : ResponseBase
{

    /// <summary>
    /// Contains details of a performed fraud prevention check
    /// </summary>
    public FraudPrevention FraudPrevention { get; set; }


    /// <summary>
    /// LiabilityShift information, replaces ThreeDs Info from api version 1.26
    /// </summary>
    public Liability Liability { get; set; }


    /// <summary>
    /// Mastercard card issuer installment payment options, if applicable
    /// </summary>
    public MastercardIssuerInstallments MastercardIssuerInstallments { get; set; }


    /// <summary>
    /// Information about the payer / card holder
    /// </summary>
    public Payer Payer { get; set; }


    /// <summary>
    /// Information about the means of payment
    /// </summary>
    public AuthorizationPaymentMeans PaymentMeans { get; set; }


    /// <summary>
    /// Information about the Secure Card Data registration outcome.
    /// </summary>
    public RegistrationResult RegistrationResult { get; set; }


    /// <summary>
    /// Information about the transaction
    /// </summary>
    public TransactionItem Transaction { get; set; }


}