using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData;

/// <summary>
/// 
/// </summary>
public class AliasInsertRequest : RequestBase
{
    /// <summary>
    /// Registration parameters
    /// </summary>
    public RegisterAlias RegisterAlias { get; set; }

    /// <summary>
    /// Type of payment means to register
    /// </summary>
    public AliasType Type { get; set; }

    /// <summary>
    /// URL which is used to redirect the payer back to the shop.
    /// </summary>
    public ReturnUrl ReturnUrl { get; set; }

    /// <summary>
    /// Custom styling resource for the Hosted Register form.
    /// </summary>
    public StylingOptions Styling { get; set; }

    /// <summary>
    /// Language used for displaying forms.
    /// </summary>
    public LanguageCodes LanguageCode { get; set; }

    /// <summary>
    /// Parameters for checking the means of payment before registering.
    /// </summary>
    public CheckTypes Check { get; set; }

    /// <summary>
    /// Used to restrict the means of payment which are available to the payer<br/>
    /// <i>AMEX, BONUS, DINERS, DIRECTDEBIT, JCB, MAESTRO, MASTERCARD, MYONE, VISA</i>
    /// </summary>
    public AliasPaymentMethods PaymentMethods { get; set; }

    /// <summary>
    /// Options for card data entry form (if applicable)
    /// </summary>
    public CardForm CardForm { get; set; }

    /// <summary>
    /// Means of payment to register
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }

    /// <summary>
    /// Url to which Saferpay will send the asynchronous confirmation for the process completion. Supported schemes are http and https. You also have to make sure to support the GET-method.
    /// </summary>
    public Notification Notification { get; set; }


}
