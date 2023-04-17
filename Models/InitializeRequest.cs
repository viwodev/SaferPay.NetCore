using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Policy;
using static System.Net.WebRequestMethods;

namespace SaferPay.Models
{
    public class InitializeRequest : RequestBase
    {

        /// <summary>
        /// This parameter let you define your payment page config (PPConfig) by name. If this parameters is not set, your default PPConfig will be applied if available.<br/>
        /// When the PPConfig can't be found (e.g. wrong name), the Saferpay basic style will be applied to the payment page.<br/>
        /// <i>Example : name of your payment page config (case-insensitive)</i>
		/// </summary>
        public string ConfigSet { get; set; }

        /// <summary>
        /// Saferpay terminal to use for this authorization<br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// Information about the payment (amount, currency, ...)<br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public InitializationPayment Payment { get; set; }

        /// <summary>
        /// Means of payment (either card data or a reference to a previously stored card).
        /// <br/> Important: Only fully PCI certified merchants may directly use the card data.If your system is not explicitly certified to handle card data directly, then use the Saferpay Secure Card Data-Storage instead.If the customer enters a new card, you may want to use the Saferpay Hosted Register Form to capture the card data through Saferpay.
        /// </summary>
		public InitializationPaymentMeans PaymentMeans { get; set; }

        /// <summary>
        /// Strong Customer Authentication (exemptions, ...)
        /// </summary>
        public InitializationAuthentication Authentication { get; set; }

        /// <summary>
        /// Information on the payer (IP-address)
        /// </summary>
        public Payer Payer { get; set; }

        /// <summary>
        /// URL which is used to redirect the payer back to the shop if the transaction requires some kind of browser redirection (3d-secure, dcc)<br/>
        /// This Url is used by Saferpay to redirect the shopper back to the merchant shop.You may add query string parameters to identify your session, but please be aware that the shopper could modify these parameters inside the browser!<br/>
        /// The whole url including query string parameters should be as short as possible to prevent issues with specific browsers and must not exceed 2000 characters.<br/>
        /// Note: you should not add sensitive data to the query string, as its contents is plainly visible inside the browser and will be logged by our web servers.<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public ReturnUrl ReturnUrl { get; set; }

        /// <summary>
        /// Used to restrict the means of payment which are available to the payer
        /// <br/>Example: ["VISA", "MASTERCARD"]
        /// </summary>
        public List<string> PaymentMethods { get; set; }

        /// <summary>
        /// If a redirect of the payer is required, these URLs will be used by Saferpay to notify you when the payer has completed the required steps and the transaction is ready to be authorized or when the operation has failed or has been aborted by the payer.<br/>
        /// If no redirect of the payer is required, then these URLs will not be called(see RedirectRequired attribute of the Transaction Initialize response).<br/>
        /// Supported schemes are http and https.You also have to make sure to support the GET-method.<br/>
        /// The whole url including query string parameters must not exceed 2000 characters.<br/><br/>
        /// <i>Note: you should not add sensitive data to the query string, as its contents are logged by our web servers.</i>
        /// </summary>
        public ReturnUrls RedirectNotifyUrls { get; set; }
    }

    public class ReturnUrl
    {
        public ReturnUrl()
        {
            
        }

        public ReturnUrl(string url)
        {
            this.Url = new Uri(url);
        }

        /// <summary>
        /// Return url for successful, failed or aborted transaction<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public Uri Url { get; set; }

        public override string ToString()
        {
            return Url.ToString();
        }

        public static implicit operator ReturnUrl(string url)
        {
            return new ReturnUrl(url);
        }

    }

    public class InitializationAuthentication
    {
        /// <summary>
        /// Type of Exemption<br/>
        /// <i>Possible values: LOW_VALUE, TRANSACTION_RISK_ANALYSIS.</i>
        /// </summary>
        public string Exemption { get; set; }

        /// <summary>
        /// 3DS Secure challenge options<br/>
        /// <i>Possible values: AVOID, FORCE.</i>
        /// </summary>
        public string ThreeDsChallenge { get; set; }
    }
}