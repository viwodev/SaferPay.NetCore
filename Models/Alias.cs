namespace SaferPay.Models
{
	public class Alias
	{
        /// <summary>
        /// Id / name of the alias<br/><br/>
        /// <i>Example: alias35nfd9mkzfw0x57iwx</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Number of days this card is stored within Saferpay. Minimum 1 day, maximum 1600 days.<br/><br/>
        /// <i>Example: 1000</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public int Lifetime { get; set; }
	}
}