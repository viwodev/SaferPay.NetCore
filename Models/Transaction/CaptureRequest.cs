using SaferPay.Models.Core;
using SaferPay.Models.Mastercard;

namespace SaferPay.Models.Transaction;

public class CaptureRequest : RequestBase
{

    #region Ctors
    public CaptureRequest() { }

    public CaptureRequest(TransactionReference transactionReference) => TransactionReference = transactionReference;

    /// <summary>
    /// Construction with Transaction ID
    /// </summary>
    /// <param name="transactionId"></param>
    public CaptureRequest(string transactionId) => TransactionReference = new TransactionReference(transactionId);

    /// <summary>
    /// Creates CaptureRequest instance for given TransactionId
    /// </summary>
    /// <param name="transactionId"></param>
    /// <returns></returns>
    public static CaptureRequest Create(string transactionId) => new CaptureRequest(transactionId);
    #endregion

    #region Props
    /// <summary>
    /// Currency must match the original transaction currency (request will be declined if currency does not match)
    /// </summary>
    public Amount Amount { get; set; }

    /// <summary>
    /// Optional Marketplace capture parameters.
    /// </summary>
    public Marketplace Marketplace { get; set; }

    /// <summary>
    /// Selected Mastercard card issuer installment payment option, if applicable
    /// </summary>
    public MastercardIssuerInstallments MastercardIssuerInstallments { get; set; }

    /// <summary>
    /// Optional Merchant Fund Distributor capture parameters.
    /// </summary>
    public MerchantFundDistributor MerchantFundDistributor { get; set; }

    /// <summary>
    /// Optional pending notification capture options for Paydirekt transactions.
    /// </summary>
    public Notification PendingNotification { get; set; }

    /// <summary>
    /// Reference to authorization.
    /// </summary>
    public TransactionReference TransactionReference { get; set; }
    #endregion

}