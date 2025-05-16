using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;
using SaferPay.Models.PaymentPage;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents the configuration for the address form used in the Saferpay Payment Page.
/// </summary>
/// <remarks>
/// This class allows you to specify how and where the payer's address data is collected during the
/// payment process. It also provides options to define mandatory fields that the payer must complete if the address
/// form is displayed.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class AddressForm
{

    /// <summary>
    /// Specifies if and where Saferpay should take the payer's address data from.<br/><br/>
    /// SAFERPAY will result in an address form being shown to the payer in the Saferpay Payment Page.<br/>
    /// PREFER_PAYMENTMETHOD will retrieve the address data from the means of payment if supported.PREFER_PAYMENTMETHOD will fall back to SAFERPAY if not available with the chosen payment method.<br/>
    /// For NONE no address form will be displayed and no address data will be retrieved from the means of payment.<br/><br/>    
    /// </summary>
    /// <remarks>
    /// <i>Possible values</i>
    /// <list type="bullet">
    /// <item><see cref="AddressSources.NONE"/></item>
    /// <item><see cref="AddressSources.SAFERPAY"/></item>
    /// <item><see cref="AddressSources.PREFER_PAYMENTMETHOD"/></item>
    /// </list>
    /// </remarks>
    [Mandatory("AddressSource field is mandatory.")]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    public AddressSources AddressSource { get; set; }


    /// <summary>
    /// List of fields which the payer must enter to proceed with the payment.<br/>
    /// This is only applicable if Saferpay displays the address form.<br/><br/>
    /// If no mandatory fields are sent, all fields except SALUTATION, COMPANY and PHONE are mandatory.<br/><br/>
    /// </summary>
    /// <remarks>
    /// <i>Possible values</i>
    /// <list type="bullet">
    /// <item><see cref="AddressFormMandatoryFields.CITY"/></item>
    /// <item><see cref="AddressFormMandatoryFields.COMPANY"/></item>
    /// <item><see cref="AddressFormMandatoryFields.VATNUMBER"/></item>
    /// <item><see cref="AddressFormMandatoryFields.COUNTRY"/></item>
    /// <item><see cref="AddressFormMandatoryFields.EMAIL"/></item>
    /// <item><see cref="AddressFormMandatoryFields.FIRSTNAME"/></item>
    /// <item><see cref="AddressFormMandatoryFields.LASTNAME"/></item>
    /// <item><see cref="AddressFormMandatoryFields.PHONE"/></item>
    /// <item><see cref="AddressFormMandatoryFields.SALUTATION"/></item>
    /// <item><see cref="AddressFormMandatoryFields.STATE"/></item>
    /// <item><see cref="AddressFormMandatoryFields.STREET"/></item>
    /// <item><see cref="AddressFormMandatoryFields.ZIP"/></item>
    /// </list>
    /// </remarks>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    public List<AddressFormMandatoryFields> MandatoryFields { get; set; }
}
