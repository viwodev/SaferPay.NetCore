namespace SaferPay.Models.Core
{
    /// <summary>
    /// Information about the refund (amount, currency, ...)
    /// </summary>
    public class Refund
    {

        /// <summary>
        /// Amount data
        /// </summary>
        public Amount Amount { get; set; }

        /// <summary>
        /// Description provided by merchant
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Reference defined by the merchant.<br/><br/>
        /// <i>Id[1..80]</i><br/><br/>
        /// <i>Example: c52ad18472354511ab2c33b59e796901</i>
        /// </summary>
		public string OrderId { get; set; }
    }
}