namespace SaferPay.Models.Core
{
    /// <summary>
    /// Notification options
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Email addresses to which a confirmation email will be sent to the merchants after successful authorizations.A maximum of 10 email addresses is allowed.<br/><br/>
		/// <i>Example: ["merchant1@saferpay.com", "merchant2@saferpay.com"]</i>
		/// </summary>
		public List<string> MerchantEmails { get; set; }

        /// <summary>
        /// Email address to which a confirmation email will be sent to the payer after successful authorizations.
        /// </summary>
        public string PayerEmail { get; set; }

        /// <summary>
        /// Email address to which a confirmation email will be sent to the payer after successful authorizations processed with DCC. This option can only be used when the field PayerEmail is not set.
        /// <br/><br/><i>Example: payer@saferpay.com</i>
        /// </summary>
        public string PayerDccReceiptEmail { get; set; }

        /// <summary>
        /// Url to which Saferpay will send the asynchronous success notification for the transaction. Supported schemes are http and https. You also have to make sure to support the GET-method.
        /// <br/><br/><i>Example: https://merchanthost/notify/123</i>
        /// </summary>
        public string SuccessNotifyUrl { get; set; }

        /// <summary>
        /// Url to which Saferpay will send the asynchronous failure notification for the transaction. Supported schemes are http and https. You also have to make sure to support the GET-method.
        /// <br/><br/><i>Example: https://merchanthost/notify/123</i>
        /// </summary>
        public string FailNotifyUrl { get; set; }

    }
}