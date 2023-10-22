namespace SaferPay.Models.Core
{
    public class Alias
    {
        /// <summary>
        /// <b>Id <i>![Mandatory]</i></b><br/><br/>
        /// Id / name of the alias<br/><br/>
        /// <i>
        /// Id[1..40]<br/>
        /// Example: alias35nfd9mkzfw0x57iwx
        /// </i>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Verification code (CVV, CVC) if applicable (if the alias referenced is a card).<br/><br/>
        /// <i>
        /// Numeric[3..4]<br/>
        /// Example: 123
        /// </i>
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Number of days this card is stored within Saferpay. Minimum 1 day, maximum 1600 days.<br/><br/>
        /// <i>Example: 1000</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public int Lifetime { get; set; }
    }
}