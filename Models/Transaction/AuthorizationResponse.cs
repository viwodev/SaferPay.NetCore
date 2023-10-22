using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class AuthorizationResponse : ResponseBase
	{
		public TransactionItem Transaction { get; set; }
		public AuthorizationPaymentMeans PaymentMeans { get; set; }
		public RegistrationResult RegistrationResult { get; set; }
		public Payer Payer { get; set; }
		public ThreeDs ThreeDs { get; set; }
	}
}
