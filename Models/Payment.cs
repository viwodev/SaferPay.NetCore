namespace SaferPay.Models
{
    public abstract class BasePayment
    {
        /// <summary>
        /// Amount data (currency, value, etc.)<br/>
		/// <strong>Mandatory</strong>
        /// </summary>
        public Amount Amount { get; set; }

        /// <summary>
        /// Unambiguous order identifier defined by the merchant / shop. This identifier might be used as reference later on.<br/>
		/// <strong>Recommended</strong>
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Text which will be printed on payer's debit note. Supported by SIX Acquiring. No guarantee that it will show up on the payer's debit note, because his bank has to support it too.
        /// Please note that maximum allowed characters are rarely supported.It's usually around 10-12.
        /// </summary>
        public string PayerNote { get; set; }

        /// <summary>
        /// A human readable description provided by the merchant that can be displayed in web sites.<br/>
        /// <i>Utf8[1..1000]</i>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Mandate reference of the payment. Needed for German direct debits (ELV) only. The value has to be unique.
        /// </summary>
		public string MandateId { get; set; }
    }

    public class AuthorizationPayment : BasePayment
    {
    }

    /// <summary>
    /// Information about the payment (amount, currency, ...)
    /// </summary>
    public class InitializationPayment : BasePayment
    {

        public InitializationPayment()
        {
        }

        public InitializationPayment(decimal amount, string currenyCode, string orderId)
        {
            this.OrderId = orderId;
            this.Amount = new Amount(amount, currenyCode);
        }

        /// <summary>
        /// Specific payment options
        /// </summary>
		public PaymentOptions Options { get; set; }

        /// <summary>
        /// Recurring options – cannot be combined with Installment.
        /// </summary>
		public RecurringOptions Recurring { get; set; }
    }
}