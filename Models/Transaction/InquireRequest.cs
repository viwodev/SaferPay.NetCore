using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class InquireRequest : RequestBase
    {
        public InquireRequest() { }

        /// <summary>
        /// Construction with Transaction ID
        /// </summary>
        /// <param name="transactionId"></param>
        public InquireRequest(string transactionId)
        {
            TransactionReference = new TransactionReference(transactionId);
        }

        /// <summary>
        /// Reference to authorization.
        /// </summary>
        public TransactionReference TransactionReference { get; set; }
    }
}
