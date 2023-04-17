using System;

namespace SaferPay.Models
{
    /// <summary>
    /// Mandatory if RedirectRequired is true. Contains the URL for the redirect to use for example the Saferpay hosted register form.
    /// </summary>
	public class InitializationResponseRedirect
	{

        /// <summary>
        /// Redirect-URL. Used to either redirect the payer or let him enter his means of payment.<br/><br/>
        /// <i>Example: https://www.saferpay.com/VT2/api/...</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public Uri RedirectUrl { get; set; }

        /// <summary>
        /// If 'true', the given URL must either be used as the target of a form (POST) containing card data entered by the card holder or to redirect the browser to (GET). If ‘false’, a GET redirect without additional data must be performed.<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public bool PaymentMeansRequired { get; set; }

        /// <summary>
        /// Returns Redirect URL String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RedirectUrl != null ? RedirectUrl.ToString() : string.Empty;
        }
    }
}