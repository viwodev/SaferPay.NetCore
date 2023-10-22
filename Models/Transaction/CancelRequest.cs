using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public partial class CancelRequest : RequestBase
    {

        public CancelRequest() { }

        /// <summary>
        /// Construction with Transaction ID
        /// </summary>
        /// <param name="transactionId"></param>
        public CancelRequest(string transactionId)
        {
            TransactionReference = new TransactionReference(transactionId);
        }

        public TransactionReference TransactionReference { get; set; }

    }
}