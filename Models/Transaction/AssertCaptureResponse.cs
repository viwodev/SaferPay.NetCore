using SaferPay.Models.Core;
using SaferPay.Enums;

namespace SaferPay.Models.Transaction
{
    public class AssertCaptureResponse : ResponseBase
    {
        /// <summary>
        /// Id of the referenced transaction.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// OrderId of the referenced transaction. If present.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Current status of the capture. (PENDING is only used for paydirekt at the moment)
        /// </summary>
        public CaptureStatus Status { get; set; }

        /// <summary>
        /// Date and time of capture. Not set if the capture state is pending.
        /// </summary>
        public DateTimeOffset Date { get; set; }
    }
}
