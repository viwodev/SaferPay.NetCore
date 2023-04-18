using SaferPay.Enums;

namespace SaferPay.Models
{
    public class InitializePaymentPageRequest : RequestBase
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
        /// Used to restrict the means of payment which are available to the payer for this transaction. If only one payment method id is set, the payment selection step will be skipped.<br/><br/>
        /// <i>Possible values: ACCOUNTTOACCOUNT, ALIPAY, AMEX, BANCONTACT, BONUS, DINERS, DIRECTDEBIT, EPRZELEWY, EPS, GIROPAY, IDEAL, INVOICE, JCB, KLARNA, MAESTRO, MASTERCARD, MYONE, PAYCONIQ, PAYDIREKT, PAYPAL, POSTCARD, POSTFINANCE, SOFORT, TWINT, UNIONPAY, VISA, WLCRYPTOPAYMENTS.</i><br/><br/>
        /// <i>Example: ["VISA", "MASTERCARD"]</i>
        /// </summary>
        public List<PaymentMethodTypes> PaymentMethods { get; set; }

        /// <summary>
        /// Strong Customer Authentication (exemptions, ...)
        /// </summary>
        public InitializationAuthentication Authentication { get; set; }

        /// <summary>
        /// Used to control if wallets should be enabled on the payment selection page and to go directly to the given wallet (if exactly one wallet is filled and PaymentMethods is not set).<br/><br/>
        /// <i>Possible values: MASTERPASS, APPLEPAY, GOOGLEPAY.</i><br/><br/>
        /// <i>Example: ["MASTERPASS"]</i>
        /// </summary>
        public List<WalletTypes> Wallets { get; set; }

        /// <summary>
        /// Information on the payer (IP-address)
        /// </summary>
        public Payer Payer { get; set; }

        /// <summary>
        /// If the given means of payment should be stored in Saferpay Secure Card Data storage (if applicable)
        /// </summary>
        public RegisterAlias RegisterAlias { get; set; }

        /// <summary>
        /// URL which is used to redirect the payer back to the shop<br/><br/>
        /// <i>This Url is used by Saferpay to redirect the shopper back to the merchant shop. You may add query string parameters to identify your session, but please be aware that the shopper could modify these parameters inside the browser!
        /// The whole url including query string parameters should be as short as possible to prevent issues with specific browsers and must not exceed 2000 characters.
        /// Note: you should not add sensitive data to the query string, as its contents is plainly visible inside the browser and will be logged by our web servers.</i><br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public ReturnUrl ReturnUrl { get; set; }


    }
}
