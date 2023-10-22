using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class RefundResponse : ResponseBase
    {
        public TransactionItem Transaction { get; set; }
        public AuthorizationPaymentMeans PaymentMeans { get; set; }
        public Dcc Dcc { get; set; }
    }
}