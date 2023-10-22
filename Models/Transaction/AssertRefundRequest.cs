using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class AssertRefundRequest : RequestBase
    {
        public AssertRefundRequest() { }

        /// <summary>
        /// Construction with Transaction ID
        /// </summary>
        /// <param name="transactionId"></param>
        public AssertRefundRequest(string transactionId)
        {
            TransactionReference = new TransactionReference(transactionId);
        }

        public TransactionReference TransactionReference { get; set; }
    }
}
