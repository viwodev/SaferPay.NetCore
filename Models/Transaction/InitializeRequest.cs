using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

/// <summary>
/// Transaction Request
/// </summary>
public class InitializeRequest : RequestBase
{

    public InitializeRequest() { }

    public InitializeRequest(string terminalId, decimal amount, string currencyCode, string orderId, string returnURL)
    {
        this.TerminalId = terminalId;
        this.Payment = new Payment(amount, currencyCode, orderId);
        this.ReturnUrl = returnURL;
    }

    public InitializeRequest SetCard(string number, int expMonth, int expYear, string verificationCode = "", string holderName = "")
    {
        this.PaymentMeans = new Card(number, expMonth, expYear, verificationCode, holderName);
        return this;
    }

    public InitializeRequest SetCard(string number, int expMonth, int expYear, int verificationCode, string holderName = "")
    {
        this.PaymentMeans = new Card(number, expMonth, expYear, verificationCode, holderName);
        return this;
    }

    /// <summary>
    /// Strong Customer Authentication (exemptions, ...)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Authentication Authentication { get; set; }

    /// <summary>
    /// Options for card data entry form (if applicable)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public CardForm CardForm { get; set; }

    /// <summary>
    /// <b>ConfigSet</b><br/><br/>
    /// This parameter let you define your payment page config (PPConfig) by name. If this parameters is not set, your default PPConfig will be applied if available.<br/>
    /// When the PPConfig can't be found (e.g. wrong name), the Saferpay basic style will be applied to the payment page.<br/><br/>
    /// <i>Id[1..20]</i><br/>
    /// <i>Example : name of your payment page config (case-insensitive)</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ConfigSet { get; set; }

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
    /// Information on the payer (IP-address)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Payer Payer { get; set; }

    /// <summary>
    /// <b>Payment *<i>[Mandatory]</i></b><br/><br/>
    /// Information about the payment (amount, currency, ...)<br/>
    /// </summary>
    public Payment Payment { get; set; }

    /// <summary>
    /// Means of payment (either card data or a reference to a previously stored card).
    /// <br/> Important: Only fully PCI certified merchants may directly use the card data.If your system is not explicitly certified to handle card data directly, then use the Saferpay Secure Card Data-Storage instead.If the customer enters a new card, you may want to use the Saferpay Hosted Register Form to capture the card data through Saferpay.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public PaymentMeans PaymentMeans { get; set; }

    /// <summary>
    /// <b>PaymentMethods</b><br/><br/>
    /// Used to restrict the means of payment which are available to the payer<br/><br/>
    /// <i>Possible values: AMEX, BANCONTACT, BONUS, DINERS, DIRECTDEBIT, JCB, MAESTRO, MASTERCARD, MYONE, VISA. Additional values may be accepted but are ignored.</i><br/>
    /// <i>Example: ["VISA", "MASTERCARD"]</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<TransactionPaymentMethods> PaymentMethods { get; set; }

    /// <summary>
    /// If a redirect of the payer is required, these URLs will be used by Saferpay to notify you when the payer has completed the required steps and the transaction is ready to be authorized or when the operation has failed or has been aborted by the payer.<br/>
    /// If no redirect of the payer is required, then these URLs will not be called(see RedirectRequired attribute of the Transaction Initialize response).<br/>
    /// Supported schemes are http and https.You also have to make sure to support the GET-method.<br/>
    /// The whole url including query string parameters must not exceed 2000 characters.<br/><br/>
    /// <i>Note: you should not add sensitive data to the query string, as its contents are logged by our web servers.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public ReturnUrls RedirectNotifyUrls { get; set; }

    /// <summary>
    /// URL which is used to redirect the payer back to the shop if the transaction requires some kind of browser redirection (3d-secure, dcc)<br/>
    /// This Url is used by Saferpay to redirect the shopper back to the merchant shop.You may add query string parameters to identify your session, but please be aware that the shopper could modify these parameters inside the browser!<br/>
    /// The whole url including query string parameters should be as short as possible to prevent issues with specific browsers and must not exceed 2000 characters.<br/>
    /// Note: you should not add sensitive data to the query string, as its contents is plainly visible inside the browser and will be logged by our web servers.<br/><br/>
    /// <strong>Mandatory</strong>
    /// </summary>
    public ReturnUrl ReturnUrl { get; set; }

    /// <summary>
    /// Optional risk factors
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public RiskFactors RiskFactors { get; set; }

    /// <summary>
    /// Styling options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public StylingOptions Styling { get; set; }

    /// <summary>
    /// <b>TerminalId *<i>[Mandatory]</i></b><br/><br/>
    /// Saferpay terminal to use for this authorization<br/><br/>
    /// <i>Numeric[8..8]<br/>
    /// Example: 12341234
    /// </i>
    /// </summary>
    public string TerminalId { get; set; }

}