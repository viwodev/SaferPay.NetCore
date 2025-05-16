using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class AuthenticationResult
{
    /// <summary>
    /// The result of the card holder authentication.<br/><br/>
    /// <i>Possible values: OK, NOT_SUPPORTED.</i>
    /// </summary>
    public AuthenticationResultTypes Result { get; set; }

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
        return $"{Result.ToString()} [{Message}]";
    }
}
