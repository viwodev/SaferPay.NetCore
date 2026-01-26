using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class AlternativePaymentRequest : RequestBase
{

    /// <summary>
    /// Token returned by initial call.
    /// </summary>
    public string Token { get; set; }
}
