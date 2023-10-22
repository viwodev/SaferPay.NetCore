using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class CaptureRequest : RequestBase
    {

        public CaptureRequest()
        {
        }

        /// <summary>
        /// Reference to authorization.
        /// </summary>
        public TransactionReference TransactionReference { get; set; }

        public CaptureRequest(TransactionReference transactionReference)
        {
            TransactionReference = transactionReference;
        }

        /// <summary>
        /// Construction with Transaction ID
        /// </summary>
        /// <param name="transactionId"></param>
        public CaptureRequest(string transactionId)
        {
            TransactionReference = new TransactionReference(transactionId);
        }

        /// <summary>
        /// Currency must match the original transaction currency (request will be declined if currency does not match)
        /// </summary>
        public Amount Amount { get; set; }

        /// <summary>
        /// Creates CaptureRequest instance for given TransactionId
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public static CaptureRequest Create(string transactionId)
        {
            return new CaptureRequest(transactionId);
        }
    }
}