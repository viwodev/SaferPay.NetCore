using SaferPay.Models.Attributes;
using SaferPay.Models.Core;

namespace SaferPay.Models.Batch;

public class BatchRequest : RequestBase
{
    /// <summary>
    /// Saferpay Terminal-Id
    /// </summary>
    [Mandatory]
    public string TerminalId { get; set; }
}
