using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData;

public class InsertDirectRequest : RequestBase
{

    /// <summary>
    /// Parameters for checking the means of payment before registering. IMPORTANT NOTE: The Check function is only available for SIX Payment Services VISA and Mastercard acquiring contracts!
    /// </summary>
    public Check Check { get; set; }

    /// <summary>
    /// If you want to use an external 3DS solution, you can provide the authentication data here.<br/><br/>
    /// Additionally the Check object must be sent with type ONLINE_STRONG
    /// </summary>
    public ExternalThreeDS ExternalThreeDS { get; set; }

    /// <summary>
    /// Contains that is received from the issuer in the response of a successful payment by other payment providers. This data will be used for authorizations based on this alias.
    /// </summary>
    public IssuerReference IssuerReference { get; set; }

    /// <summary>
    /// Means of payment to register
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }

    /// <summary>
    /// Registration parameters
    /// </summary>
    public RegisterAlias RegisterAlias { get; set; }

}
