using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class DccInquiryResponse : ResponseBase
{
    /// <summary>
    /// Information if dcc is possible for requested card
    /// </summary>
    public bool DccAvailable { get; set; }

    /// <summary>
    /// Information about the means of payment
    /// </summary>
    public DccInfo DccInfo { get; set; }

    /// <summary>
    /// Id of the referenced transaction.
    /// </summary>
    public string DccToken { get; set; }

    /// <summary>
    /// Expiration date / time of the generated DCC token in ISO 8601 format in UTC.
    /// After this time is exceeded, the DCC proposal cannot be used anymore
    /// </summary>
    public DateTime Expiration { get; set; }
}
