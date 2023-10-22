using SaferPay.Enums;

namespace SaferPay.Models.Core
{
    public class CheckResult
    {
        /// <summary>
        /// The result of the card check.
        /// </summary>
        public CheckResultTypes Result { get; set; }

        /// <summary>
        /// More details, if available. Contents may change at any time, so don’t parse it.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// More details about the card holder authentication.
        /// </summary>
        public AuthenticationResult Authentication { get; set; }

        public IssuerReference IssuerReference { get; set; }
    }
}
