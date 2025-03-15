using SaferPay.Enums;

namespace SaferPay.Models.Core;

/// <summary>
/// Card data
/// </summary>
public class AuthorizationCard
{

    /// <summary>
    /// ISO 2-letter country code of the card origin (if available)<br/><br/>
    /// <i>Example: CH</i>
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Month of expiration (eg 9 for September)<br/><br/>
    /// <i>Example: 9</i>
    /// </summary>
    public int ExpMonth { get; set; }

    /// <summary>
    /// Year of expiration<br/><br/>
    /// <i>Example: 2015</i>
    /// </summary>
    public int ExpYear { get; set; }

    /// <summary>
    /// Name of the card holder (if known)<br/><br/>
    /// <i>Example: John Doe</i>
    /// </summary>
    public string HolderName { get; set; }

    /// <summary>
    /// The Segment of card holder. Only returned for Alias/AssertInsert, Alias/InsertDirect and Alias/Update calls if available.<br/><br/>
    /// <i>Possible values: UNSPECIFIED, CONSUMER, CORPORATE, CORPORATE_AND_CONSUMER.<br/>
    ///Example: CORPORATE</i>
    /// </summary>
    public HolderSegmentTypes HolderSegment { get; set; }

    /// <summary>
    /// Masked card number<br/><br/>
    /// <i>Example: 912345xxxxxx1234</i>
    /// </summary>
    public string MaskedNumber { get; set; }

    /// <summary>
    /// Contains information about the tokenPAN if the transaction, or the referenced transaction, was conducted with a scheme token PAN.
    /// </summary>
    public TokenPan TokenPan { get; set; }


    /// <summary>
    /// The HashValue, if the hash generation is configured for the customer.
    /// </summary>
    public string HashValue { get; set; }
}