namespace SaferPay.Models
{
    public class InquireRequest : RequestBase
    {
        public InquireRequest() { }

        /// <summary>
        /// Reference to authorization.
        /// </summary>
        public TransactionReference TransactionReference { get; set; }
    }
}
