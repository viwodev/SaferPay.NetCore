namespace SaferPay.Models.Core
{
    public class Redirect
    {
        /// <summary>
        /// Redirect-URL. Used to either redirect the payer or let him enter his means of payment.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// If 'true', the given URL must either be used as the target of a form (POST) containing card data entered by the card holder or to redirect the browser to (GET). If ‘false’, a GET redirect without additional data must be performed.
        /// </summary>
        public bool PaymentMeansRequired { get; set; }

        public override string ToString()
        {
            return RedirectUrl != null ? RedirectUrl.ToString() : string.Empty;
        }
    }
}