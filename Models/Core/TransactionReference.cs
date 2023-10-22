namespace SaferPay.Models.Core
{
    public class TransactionReference
    {
        public TransactionReference()
        {
        }

        public string TransactionId { get; set; }

        public TransactionReference(string transactionId)
        {
            TransactionId = transactionId;
        }

        public string OrderId { get; set; }
    }
}