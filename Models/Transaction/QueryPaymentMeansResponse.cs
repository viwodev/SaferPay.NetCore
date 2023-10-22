using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    /// <summary>
    /// Query Payment Means Response
    /// </summary>
    public class QueryPaymentMeansResponse : ResponseBase
    {

        /// <summary>
        /// Information about the means of payment
        /// </summary>
        public PaymentMeans PaymentMeans { get; set; }

        /// <summary>
        /// Information about the payer / card holder
        /// </summary>
        public Payer Payer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RedirectRequired { get; set; }

        /// <summary>
        /// Available if DCC may be performed.
        /// </summary>
        public string RedirectUrl { get; set; }

    }
}
