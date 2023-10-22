using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class MultipartFinalizeRequest : RequestBase
    {
        public MultipartFinalizeRequest() { }

        /// <summary>
        /// Construction with Transaction ID
        /// </summary>
        /// <param name="transactionId"></param>
        public MultipartFinalizeRequest(string transactionId)
        {
            TransactionReference = new TransactionReference(transactionId);
        }

        /// <summary>
        /// Reference to authorization.
        /// </summary>
        public TransactionReference TransactionReference { get; set; }

    }
}
