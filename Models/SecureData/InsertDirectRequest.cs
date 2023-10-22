using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData
{
    public class InsertDirectRequest: RequestBase
    {
        /// <summary>
        /// Registration parameters
        /// </summary>
        public RegisterAlias RegisterAlias { get; set; }

        /// <summary>
        /// Means of payment to register
        /// </summary>
        public PaymentMeans PaymentMeans { get; set; }

        /// <summary>
        /// Parameters for checking the means of payment before registering. IMPORTANT NOTE: The Check function is only available for SIX Payment Services VISA and Mastercard acquiring contracts!
        /// </summary>
        public Check Check { get; set; }

        /// <summary>
        /// Contains that is received from the issuer in the response of a successful payment by other payment providers. This data will be used for authorizations based on this alias.
        /// </summary>
        public IssuerReference IssuerReference { get; set; }
    }
}
