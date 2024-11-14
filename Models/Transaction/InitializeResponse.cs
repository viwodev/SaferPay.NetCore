using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class InitializeResponse : ResponseBase
{

    /// <summary>
    /// Expiration date / time of the generated token in ISO 8601 format in UTC.<br/>
    /// After this time is exceeded, the token will not be accepted for any further actions except Asserts.<br/><br/>
    /// <i>Example: 2015-01-30T13:45:22.258+02:00</i>
    /// </summary>
    public DateTimeOffset Expiration { get; set; }


    /// <summary>
    /// RedirectUrl for the payment page transaction. Simply add this to a "Pay Now"-button or do an automatic redirect.
    /// </summary>
    public string RedirectUrl { get; set; }


    /// <summary>
    /// True if a redirect must be performed to continue, false otherwise<br/><br/>
    /// <strong>Mandatory</strong>
    /// </summary>
    public bool RedirectRequired { get; set; }


    /// <summary>
    /// Id for referencing later<br/><br/>
    /// <i>Example: 234uhfh78234hlasdfh8234e</i>
    /// </summary>
    public string Token { get; set; }


    /// <summary>
    /// Indicates if liability shift to issuer is possible or not. Not present if PaymentMeans container was not present in InitializeTransaction request. True, if liability shift to issuer is possible, false if not.
    /// </summary>
    public bool LiabilityShift { get; set; }


    /// <summary>
    /// Mandatory if RedirectRequired is true. Contains the URL for the redirect to use for example the Saferpay hosted register form.
    /// </summary>
    public Redirect Redirect { get; set; }

}