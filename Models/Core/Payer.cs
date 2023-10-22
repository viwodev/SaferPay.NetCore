namespace SaferPay.Models.Core
{
    /// <summary>
    /// Information on the payer (IP-address)
    /// </summary>
	public class Payer
    {

        /// <summary>
        /// IPv4 address of the card holder / payer if available. Dotted quad notation.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// IPv6 address of the card holder / payer if available.
        /// </summary>
        public string Ip6Address { get; set; }

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
        /// Payer identifier defined by the merchant / shop. Use a unique id for your customer (a UUID is highly recommended).<br/>
        /// For GDPR reasons, we don't recommend using an id which contains personal data (eg. no name).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Information on the payers delivery address
        /// </summary>
        public PayerAddress DeliveryAddress { get; set; }

        /// <summary>
        /// Browser accept header
        /// </summary>
        public string AcceptHeader { get; set; }

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Is Java enabled
        /// </summary>
        public bool JavaEnabled { get; set; }

        /// <summary>
        /// Is JavaScript enabled
        /// </summary>
        public bool JavaScriptEnabled { get; set; }

        /// <summary>
        /// Screen width
        /// </summary>
        public int ScreenWidth { get; set; }

        /// <summary>
        /// Screen height
        /// </summary>
        public int ScreenHeight { get; set; }

        /// <summary>
        /// Color depth
        /// </summary>
        public string ColorDepth { get; set; }

        /// <summary>
        /// Time zone offset in minutes
        /// </summary>
        public int TimeZoneOffsetMinutes { get; set; }
    }
}