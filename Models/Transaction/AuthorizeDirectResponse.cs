using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class AuthorizeDirectResponse : ResponseBase
    {
        public TransactionItem Transaction { get; set; }
        public AuthorizationPaymentMeans PaymentMeans { get; set; }
        public RegistrationResult RegistrationResult { get; set; }
        public Payer Payer { get; set; }
    }
}