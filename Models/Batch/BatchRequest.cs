using SaferPay.Models.Core;

namespace SaferPay.Models.Batch
{
    public class BatchRequest : RequestBase
    {
        /// <summary>
        /// Saferpay Terminal-Id
        /// </summary>
        public string TerminalId { get; set; }
    }
}
