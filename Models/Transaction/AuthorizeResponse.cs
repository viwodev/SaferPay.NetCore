using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class AuthorizeResponse : ResponseBase
    {

        /// <summary>
        /// Information about the transaction<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public TransactionItem Transaction { get; set; }

        /// <summary>
        /// Information about the means of payment<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public AuthorizationPaymentMeans PaymentMeans { get; set; }

        /// <summary>
        /// Information about the payer / card holder
        /// </summary>
		public Payer Payer { get; set; }

        /// <summary>
        /// Information about the Secure Card Data registration outcome.
        /// </summary>
        public RegistrationResult RegistrationResult { get; set; }

        /// <summary>
        /// Mastercard card issuer installment payment options, if applicable
        /// </summary>
        public MastercardIssuerInstallments MastercardIssuerInstallments { get; set; }

        /// <summary>
        /// Contains details of a performed fraud prevention check
        /// </summary>
        public FraudPrevention FraudPrevention { get; set; }

        /// <summary>
        /// LiabilityShift information, replaces ThreeDs Info from api version 1.8
        /// </summary>
        public Liability Liability { get; set; }

        /// <summary>
        /// Dcc information, if applicable
        /// </summary>
        public Dcc Dcc { get; set; }

    }
}