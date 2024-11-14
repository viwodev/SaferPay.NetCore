using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

public class AddressForm
{
    /// <summary>
    /// Specifies if and where Saferpay should take the payer's address data from.<br/>
    /// SAFERPAY will result in an address form being shown to the payer in the Saferpay Payment Page.<br/>
    /// PREFER_PAYMENTMETHOD will retrieve the address data from the means of payment if supported.PREFER_PAYMENTMETHOD will fall back to SAFERPAY if not available with the chosen payment method.<br/>
    /// For NONE no address form will be displayed and no address data will be retrieved from the means of payment.<br/><br/>
    /// <i>NONE, SAFERPAY, PREFER_PAYMENTMETHOD</i>
    /// </summary>
    [Mandatory]
    public AddressSources AddressSource { get; set; }

    /// <summary>
    /// List of fields which the payer must enter to proceed with the payment.<br/>
    /// This is only applicable if Saferpay displays the address form.<br/>
    /// If no mandatory fields are sent, all fields except SALUTATION, COMPANY and PHONE are mandatory.<br/><br/>
    /// <i>Possible values: CITY, COMPANY, VATNUMBER, COUNTRY, EMAIL, FIRSTNAME, LASTNAME, PHONE, SALUTATION, STATE, STREET, ZIP.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<string> MandatoryFields { get; set; }
}
