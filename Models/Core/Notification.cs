using Newtonsoft.Json;
using SaferPay.Models.Attributes;
using SaferPay.Models.PaymentPage;

namespace SaferPay.Models.Core;


/// <summary>
/// Represents the notification settings for a transaction, including URLs for asynchronous notifications and email
/// addresses for confirmation messages.
/// </summary>
/// <remarks>
/// This class is used to configure various notification endpoints and email recipients for
/// transaction-related events, such as success, failure, or pending states. It supports both merchant and payer
/// notifications.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class Notification
{

    /// <summary>
    /// Url to which Saferpay will send the asynchronous failure notification for the transaction. Supported schemes are http and https. You also have to make sure to support the GET-method.
    /// <br/><br/><i>Example: https://merchanthost/notify/123</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    [Recommended]
    public string FailNotifyUrl { get; set; }


    /// <summary>
    /// Email addresses to which a confirmation email will be sent to the merchants after successful authorizations.A maximum of 10 email addresses is allowed.<br/><br/>
    /// <i>Example: ["merchant1@saferpay.com", "merchant2@saferpay.com"]</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    public List<string> MerchantEmails { get; set; }


    /// <summary>
    /// Email address to which a confirmation email will be sent to the payer after successful authorizations processed with DCC. This option can only be used when the field PayerEmail is not set.
    /// <br/><br/><i>Example: payer@saferpay.com</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    public string PayerDccReceiptEmail { get; set; }


    /// <summary>
    /// Email address to which a confirmation email will be sent to the payer after successful authorizations.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    public string PayerEmail { get; set; }


    /// <summary>
    /// Url to which Saferpay will send the asynchronous success notification for the transaction. Supported schemes are http and https. You also have to make sure to support the GET-method.
    /// <br/><br/><i>Example: https://merchanthost/notify/123</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    [Recommended]
    public string SuccessNotifyUrl { get; set; }


    /// <summary>
    /// Url which is called by Saferpay if an action could not be completed synchronously and was reported with a ‘pending’ state (eg CAPTURE_PENDING or REFUND_PENDING). Up until now, this is only applicable for Paydirekt transactions or WL Crypto Payments refunds.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string NotifyUrl { get; set; }

}