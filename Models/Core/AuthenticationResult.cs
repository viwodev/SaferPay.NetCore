using SaferPay.Enums;
using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

/// <summary>
/// Updated V1.51
/// </summary>
public class AuthenticationResult
{

    /// <summary>
    /// Indicates whether Strong Customer Authentication (SCA) was successfully completed.
    /// </summary>
    [Mandatory]
    public bool Authenticated { get; set; }


    /// <summary>
    /// Determines how the cardholder was authenticated during card registration.<br/><br/>
    /// </summary>
    /// <remarks>Possible values: STRONG_CUSTOMER_AUTHENTICATION, FRICTIONLESS, ATTEMPT, UNSPECIFIED, NONE.</remarks>
    [Mandatory]
    public AuthenticationTypes AuthenticationType { get; set; }

    /// <summary>
    /// More details, if available. Contents may change at any time, so don’t parse it.<br/><br/>
    /// <i>Example: Card holder authentication with 3DSv2 successful.</i>
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Transaction Id, given by the MPI. References the 3D Secure version 2 process.
    /// </summary>
    public string Xid { get; set; }

    public override string ToString()
    {
        return $"{AuthenticationType.ToString()} [{Message}]";
    }
}
