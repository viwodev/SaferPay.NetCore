using System;

namespace SaferPay.Models
{
	public class ReturnUrls
	{
        /// <summary>
        /// Notification url called when the payer has completed the redirect steps successfully and the transaction is ready to be authorized.
		/// <i>Example: https://merchanthost/success/123</i><br/><br/>
		/// <strong>Mandatory</strong>
        /// </summary>
        public Uri Success { get; set; }

        /// <summary>
        /// Notification url called when the payer redirect steps have failed. The transaction cannot be authorized.
        /// <i>Example: https://merchanthost/fail/123</i><br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public Uri Fail { get; set; }
	}
}