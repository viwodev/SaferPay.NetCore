using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class QueryPaymentMeansRequest : RequestBase
    {

        public QueryPaymentMeansRequest()
        {
            
        }

        public QueryPaymentMeansRequest(string token)
        {
            this.Token = token;
        }

        /// <summary>
        /// Token returned by Initialize
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// URL which is used to redirect the payer back to the shop if the transaction requires some kind of browser redirection (3d-secure, dcc)<br/><br/>
        /// This Url is used by Saferpay to redirect the shopper back to the merchant shop. You may add query string parameters to identify your session, but please be aware that the shopper could modify these parameters inside the browser!
        /// The whole url including query string parameters should be as short as possible to prevent issues with specific browsers and must not exceed 2000 characters.
        /// Note: you should not add sensitive data to the query string, as its contents is plainly visible inside the browser and will be logged by our web servers.
        /// </summary>
        public ReturnUrl ReturnUrl { get; set; }
    }
}
