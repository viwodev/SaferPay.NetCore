using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class DccInquiryRequest : RequestBase
{

    /// <summary>
    /// Amount data (currency, value, etc.)
    /// </summary>
    public Amount Amount { get; set; }

    /// <summary>
    /// Card number without separators
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// Saferpay terminal to use for this authorization
    /// </summary>
    public string TerminalId { get; set; }
}
