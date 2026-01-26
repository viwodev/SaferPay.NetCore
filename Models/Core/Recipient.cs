using SaferPay.Enums;
using System.Diagnostics.Metrics;

namespace SaferPay.Models.Core;

public class Recipient
{

    /// <summary>
    /// The payer's city
    /// </summary>
    public string City { get; set; }


    /// <summary>
    /// The payer's company
    /// </summary>
    public string Company { get; set; }


    /// <summary>
    /// The payer's country code
    /// ISO 3166-1 alpha-2 country code
    /// (Non-standard: XK for Kosovo)
    /// </summary>
    public string CountryCode { get; set; }


    /// <summary>
    /// The payer's country subdivision code<br/><br/>
    /// Allows country codes formatted as ISO 3166 or ISO 3166-2.
    /// </summary>
    public string CountrySubdivisionCode { get; set; }


    /// <summary>
    /// The payer's date of birth in ISO 8601 extended date notation<br/><br/>
    /// YYYY-MM-DD
    /// </summary>
    public string DateOfBirth { get; set; }


    /// <summary>
    /// The payer's email address
    /// </summary>
    public string Email { get; set; }


    /// <summary>
    /// The payer's first name
    /// </summary>
    public string FirstName { get; set; }


    /// <summary>
    /// The payer's gender
    /// </summary>
    public GenderTypes Gender { get; set; }


    /// <summary>
    /// The payer's last name
    /// </summary>
    public string LastName { get; set; }


    /// <summary>
    /// The payer's phone number
    /// </summary>
    public string Phone { get; set; }


    /// <summary>
    /// The payer's street
    /// </summary>
    public string Street { get; set; }


    /// <summary>
    /// The payer's street, second line. Only use this, if you need two lines. It may not be supported by all acquirers.
    /// </summary>
    public string Street2 { get; set; }


    /// <summary>
    /// The payer's zip code
    /// </summary>
    public string Zip { get; set; }
}
