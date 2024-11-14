using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class PayerAddress
{
    /// <summary>
    /// The payer's city<br/><br/>
    /// <i>Example: Zurich</i>
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// The payer's company<br/><br/>
    /// <i>Example: ACME Corp.</i>
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    /// The payer's country code in ISO 3166-1 alpha-2 format (Non-standard: XK for Kosovo)<br/><br/>
    /// <i>Example: CH</i>
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// The payer's country subdivision code, formatted as ISO 3166 or ISO 3166-2<br/><br/>
    /// <i>Example: ZH / CH-ZH</i>
    /// </summary>
    public string CountrySubdivisionCode { get; set; }

    /// <summary>
    /// The payer's date of birth in ISO 8601 format (YYYY-MM-DD)<br/><br/>
    /// <i>Example: 1990-05-31</i>
    /// </summary>
    public string DateOfBirth { get; set; }

    /// <summary>
    /// The payer's email address<br/><br/>
    /// <i>Example: payer@provider.com</i>
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The payer's first name<br/><br/>
    /// <i>Example: John</i>
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The payer's gender (Possible values: MALE, FEMALE, DIVERSE, COMPANY)<br/><br/>
    /// <i>Example: COMPANY</i>
    /// </summary>
    public GenderTypes Gender { get; set; }

    /// <summary>
    /// The payer's last name<br/><br/>
    /// <i>Example: Doe</i>
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The payer's phone number<br/><br/>
    /// <i>Example: +41 12 345 6789</i>
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// The payer's street<br/><br/>
    /// <i>Example: Bakerstreet 32</i>
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// The payer's street, second line (Only use if two lines are needed, may not be supported by all acquirers)<br/><br/>
    /// <i>Example: Stewart House</i>
    /// </summary>
    public string Street2 { get; set; }

    /// <summary>
    /// The company's VAT number<br/><br/>
    /// </summary>
    public string VatNumber { get; set; }

    /// <summary>
    /// The payer's zip code<br/><br/>
    /// <i>Example: 8000</i>
    /// </summary>
    public string Zip { get; set; }
}