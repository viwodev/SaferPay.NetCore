using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class CancelResponse : ResponseBase
    {
        public string TransactionId { get; set; }
        public string OrderId { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}


