using SaferPay.Enums;
using SaferPay.Models.Attributes;
using System.Net;

namespace SaferPay.Models.Core;

public class ExternalThreeDS
{

    /// <summary>
    /// Access Control Server (ACS) Transaction ID
    /// </summary>
    [Mandatory("AcsTransId is mandatory!")]
    public string AcsTransId { get; set; }


    /// <summary>
    /// Mode of the 3DS authentication process.<br/><br/>
    /// <i>Possible values: CHALLENGE, FRICTIONLESS.</i>
    /// </summary>
    public AuthenticationMode AuthenticationMode { get; set; }


    /// <summary>
    /// Date and time of the authentication process in ISO 8601 format.<br/><br/>
    /// AlphaNumeric[1..2147483647]<br/>
    /// <i>Example: 2025-04-06T10:30:00.123+01:00: Represents April 6, 2025, at 10:30:00.123 in a time zone that is 1 hour ahead of UTC</i>
    /// </summary>
    [Mandatory("AuthenticationTime is mandatory!")]
    public string AuthenticationTime { get; set; }


    /// <summary>
    /// Payment System-specific value provided by the ACS or the DS using an algorithm defined by Payment System. Authentication Value may be used to provide proof of authentication.<br/><br/>
    /// <i>Base64 encoded string</i><br/>
    /// <i>String length: inclusive between 28 and 28</i>
    /// </summary>
    [Mandatory("AuthenticationValue is mandatory!")]
    public string AuthenticationValue { get; set; }


    /// <summary>
    /// Directory Server (DS) Transaction ID<br/><br/>
    /// <i></i>
    /// </summary>
    [Mandatory("DsTransId is mandatory!")]
    public string DsTransId { get; set; }


    /// <summary>
    /// Electronic Commerce Indicator<br/>
    /// Payment System-specific value provided by the ACS or the DS to indicate the results of the attempt to authenticate the Cardholder.<br/><br/>
    /// <i>AlphaNumeric[1..2]</i>
    /// </summary>
    [Mandatory("Eci is mandatory!")]
    public string Eci { get; set; }


    /// <summary>
    /// Scheme of the payment method used for the transaction.<br/><br/>
    /// <i>Possible values: MASTERCARD, VISA, JCB, DINERS, AMEX.</i>
    /// </summary>
    [Mandatory("Scheme is mandatory!")]
    public Scheme Scheme { get; set; }


    /// <summary>
    /// ThreeDS protocol version number used for the transaction.<br/><br/>
    /// <i>Example: 2.2.0</i>
    /// </summary>
    [Mandatory("ThreeDsFullVersion is mandatory!")]
    public string ThreeDsFullVersion { get; set; }


    /// <summary>
    /// 3DS Server Transaction ID
    /// </summary>
    [Mandatory("ThreeDSServerTransId is mandatory!")]
    public string ThreeDSServerTransId { get; set; }


    /// <summary>
    /// The final status of the 3DS authentication process. This indicates whether a transaction qualifies as an authenticated transaction or account verification.<br/><br/>
    /// <i>Possible values: Y, A, U, I.</i>
    /// </summary>
    [Mandatory("TransStatus is mandatory!")]
    public TransStatus TransStatus { get; set; }
}
