using SaferPay.Models.Core;

namespace SaferPay.Models.OmniChannel
{
    /// <summary>
    /// AcquireTransaction Request
    /// </summary>
    public class AcquireTransactionRequest : RequestBase
    {
        /// <summary>
        /// Saferpay terminal id
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// Unambiguous order identifier defined by the merchant/ shop. This identifier might be used as reference later on.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// SIX Transaction Reference
        /// </summary>
        public string SixTransactionReference { get; set; }
    }
}
