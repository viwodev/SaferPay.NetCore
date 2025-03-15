namespace SaferPay.Models.Core;

/// <summary>
/// Information about the refund (amount, currency, ...)
/// </summary>
public class Refund
{

    /// <summary>
    /// Amount data
    /// </summary>
    public Amount Amount { get; set; }

    /// <summary>
    /// Description provided by merchant
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Reference defined by the merchant.<br/><br/>
    /// <i>Id[1..80]</i><br/><br/>
    /// <i>Example: c52ad18472354511ab2c33b59e796901</i>
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// Text which will be printed on payer's debit note. No guarantee that it will show up on the payer's debit note, because his bank has to support it too.<br/><br/>
    /// Please note that the maximum allowed number of characters is rarely supported.It's usually around 10-12.
    /// </summary>
    public string PayerNote { get; set; }

    /// <summary>
    /// If set to true, the refund will be rejected if the sum of refunds exceeds the captured amount.<br/><br/>
    /// All authorized refunds are included in the calculation even if they have not been captured yet.Cancelled refunds are not included.<br/><br/>
    /// By default, this check is disabled.
    /// </summary>
    public bool RestrictRefundAmountToCapturedAmount { get; set; }
}