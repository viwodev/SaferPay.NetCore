using SaferPay.Models.Attributes;
using SaferPay.Models.Core;

namespace SaferPay.Models.PaymentPage;

/// <summary>
/// *<br/><br/>
/// *    Depending on the payment provider, the resulting transaction may either be an authorization or may already be captured (meaning the financial flow was already triggered). This will be visible in the status of the transaction container returned in the response.<br/><br/>
/// *    This function can be called up to 24 hours after the transaction was initialized. For pending transaction the token expiration is increased to 120 hours.<br/><br/>
/// *    If the transaction failed (the payer was redirected to the Fail url or he manipulated the return url), an error response with an http status code 400 or higher containing an error message will be returned providing some information on the transaction failure.<br/><br/>
/// *
/// </summary>
public class AssertRequest : RequestBase
{

    public AssertRequest() { }

    public AssertRequest(String token) { Token = token; }

    /// <summary>
    /// Token returned by initial call.<br/><br/>
    /// <i>Example: 234uhfh78234hlasdfh8234e</i>
    /// </summary>
    [Mandatory("Token is required!")]
    public string Token { get; set; }
}
