namespace SaferPay.Models
{
	public class AuthorizeDirectResponse
	{
		public ResponseHeader ResponseHeader { get; set; }
		public Transaction Transaction { get; set; }
		public AuthorizationPaymentMeans PaymentMeans { get; set; }
		public RegistrationResult RegistrationResult { get; set; }
		public Payer Payer { get; set; }
	}
}