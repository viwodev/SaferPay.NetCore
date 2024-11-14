using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;
using SaferPay.Models.Core;

namespace SaferPay.Models.PaymentPage;

/// <summary>
/// Payment Page Init Request
/// </summary>
public class InitializePaymentPageRequest : RequestBase
{

    #region Ctors
    public InitializePaymentPageRequest() { }

    public InitializePaymentPageRequest(string terminalId, decimal amount, string currencyCode, string orderId, string returnURL)
    {
        this.TerminalId = terminalId;
        this.Payment = new Payment(amount, currencyCode, orderId);
        this.ReturnUrl = returnURL;
    }
    #endregion

    #region Props

    /// <summary>
    /// Strong Customer Authentication (exemptions, ...)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Authentication Authentication { get; set; }

    /// <summary>
    /// Use this container if you need to get a billing address from the payer during the payment process.<br/>
    /// Saferpay can show an address form and depending on the means of payment, it is also possible to get the address from the means of payment (e.g. PayPal or any kind of wallet) if available.<br/>
    /// Check the options in the container for different behaviors.<br/>
    /// In case you also provide payer addresses, these are used as default values to prefill the address form (if displayed) and are overwritten by the final address entered by the payer or provided by the payment method.<br/>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public AddressForm BillingAddressForm { get; set; }


    /// <summary>
    /// Options for card data entry form (if applicable)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public CardForm CardForm { get; set; }

    /// <summary>
    /// Optional Condition for Authorization (only 3DSv2), to control, whether or not, transactions without LiabilityShift should be accepted. Important Note: This only filters out transactions, where the condition is conclusive before the authorization itself. It is possible, that LiabilityShift is rejected after the authorization. Please always check the Liability container, within the authorization-response, to be 100% sure, if LiabilityShift applies, or not!
    /// <i>Default: NONE(empty)</i><br/><br/>
    /// <i>Possible values: NONE, THREE_DS_AUTHENTICATION_SUCCESSFUL_OR_ATTEMPTED.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public AuthorizeConditionTypes Condition { get; set; }

    /// <summary>
    /// This parameter let you define your payment page config (PPConfig) by name. If this parameters is not set, your default PPConfig will be applied if available.<br/>
    /// When the PPConfig can't be found (e.g. wrong name), the Saferpay basic style will be applied to the payment page.<br/>
    /// <i>Example : name of your payment page config (case-insensitive)</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ConfigSet { get; set; }


    /// <summary>
    /// Use this container if you need to get a delivery address from the payer during the payment process.<br/>
    /// Saferpay can show an address form and depending on the means of payment, it is also possible to get the address from the means of payment(e.g.PayPal or any kind of wallet) if available.<br/>
    /// Check the options in the container for different behaviors.<br/>
    /// In case you also provide payer addresses, these are used as default values to prefill the address form (if displayed) and are overwritten by the final address entered by the payer or provided by the payment method.<br/>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public AddressForm DeliveryAddressForm { get; set; }

    /// <summary>
    /// Notification options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Notification Notification { get; set; }

    /// <summary>
    /// Optional order information. Only used for payment method Klarna (mandatory) and for Fraud Intelligence (optional).
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Order Order { get; set; }

    /// <summary>
    /// Information about the payer
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Payer Payer { get; set; }

    /// <summary>
    /// Information about the payment (amount, currency, ...)<br/>
    /// <strong>Mandatory</strong>
    /// </summary>
    public Payment Payment { get; set; }

    /// <summary>
    /// Used to restrict the means of payment which are available to the payer for this transaction. If only one payment method id is set, the payment selection step will be skipped.<br/><br/>
    /// <i>Possible values: ACCOUNTTOACCOUNT, ALIPAY, AMEX, BANCONTACT, BLIK, BONUS, DINERS, CARD, DIRECTDEBIT, EPRZELEWY, EPS, GIROPAY, IDEAL, INVOICE, JCB, KLARNA, MAESTRO, MASTERCARD, MYONE, PAYCONIQ, PAYDIREKT, PAYPAL, POSTFINANCEPAY, SOFORT, TWINT, UNIONPAY, VISA, WECHATPAY, WLCRYPTOPAYMENTS.</i><br/><br/>
    /// <i>Example: ["VISA", "MASTERCARD"]</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<PaymentPagePaymentMethods> PaymentMethods { get; set; }

    /// <summary>
    /// Optional. May be used to set specific options for some payment methods.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public PaymentMethodsOptions PaymentMethodsOptions { get; set; }


    /// <summary>
    /// If the given means of payment should be stored in Saferpay Secure Card Data storage (if applicable)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public RegisterAlias RegisterAlias { get; set; }


    /// <summary>
    /// <b>ReturnUrl <i>![Mandatory]</i></b><br/><br/>
    /// URL which is used to redirect the payer back to the shop<br/><br/>
    /// <i>This Url is used by Saferpay to redirect the shopper back to the merchant shop. You may add query string parameters to identify your session, but please be aware that the shopper could modify these parameters inside the browser!
    /// The whole url including query string parameters should be as short as possible to prevent issues with specific browsers and must not exceed 2000 characters.<br/><br/>
    /// Note: you should not add sensitive data to the query string, as its contents is plainly visible inside the browser and will be logged by our web servers.</i><br/><br/>
    /// <strong>* Mandatory</strong>
    /// </summary>
    [Mandatory]
    public ReturnUrl ReturnUrl { get; set; }


    /// <summary>
    /// Optional risk factors
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public RiskFactors RiskFactors { get; set; }


    /// <summary>
    /// Saferpay terminal id<br/><br/>
    /// <strong>* Mandatory</strong>
    /// </summary>
    [Mandatory]
    public string TerminalId { get; set; }


    /// <summary>
    /// Used to control if wallets should be enabled on the payment selection page.<br/><br/>
    /// <i>Possible values: APPLEPAY, GOOGLEPAY, CLICKTOPAY.</i><br/><br/>
    /// <i>Example: ["APPLEPAY"]</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<WalletTypes> Wallets { get; set; }
    #endregion

}
