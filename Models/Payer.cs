namespace SaferPay.Models
{
    /// <summary>
    /// Information on the payer (IP-address)
    /// </summary>
	public class Payer
	{

        /// <summary>
        /// Payer identifier defined by the merchant / shop. Use a unique id for your customer (a UUID is highly recommended).<br/>
        /// For GDPR reasons, we don't recommend using an id which contains personal data (eg. no name).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// IPv4 address of the card holder / payer if available. Dotted quad notation.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// The location the IpAddress, if available. This might be a valid country code or a special value for 'non-country' locations (anonymous proxy, satellite phone, ...).<br/><br/>
        /// <i>Example: NZ</i>
        /// </summary>
        public string IpLocation { get; set; }

        /// <summary>
        /// LanguageCode
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Information on the payers billing address
        /// </summary>
		public PayerAddress BillingAddress { get; set; }



        /// <summary>
        /// Information on the payers delivery address
        /// </summary>
        public PayerAddress DeliveryAddress { get; set; }

        
	}
}