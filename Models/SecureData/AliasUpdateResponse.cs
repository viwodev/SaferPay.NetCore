using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData
{
    public class AliasUpdateResponse : ResponseBase
    {
        /// <summary>
        /// Information about the registered alias.
        /// </summary>
        public Alias Alias { get; set; }

        /// <summary>
        /// Information about the registered means of payment
        /// </summary>
        public PaymentMeans PaymentMeans { get; set; }
    }
}
