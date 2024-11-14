using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class MultipartCaptureRequest : RequestBase
{
    /// <summary>
    /// Currency must match the original transaction currency (request will be declined if currency does not match)
    /// </summary>
    public Amount Amount { get; set; }

    /// <summary>
    /// Optional Marketplace capture parameters.
    /// </summary>
    public Marketplace Marketplace { get; set; }

    /// <summary>
    /// Optional Merchant Fund Distributor capture parameters.
    /// </summary>
    public MerchantFundDistributor MerchantFundDistributor { get; set; }

    /// <summary>
    /// Must be unique. It identifies each individual step and is especially important for follow-up actions such as refund.
    /// </summary>
    public string OrderPartId { get; set; }

    /// <summary>
    /// Reference to authorization.
    /// </summary>
    public TransactionReference TransactionReference { get; set; }

    /// <summary>
    /// 'PARTIAL' if more captures should be possible later on, 'FINAL' if no more captures will be done on this authorization.
    /// </summary>
    public MultipartCaptureTypes Type { get; set; }
}
