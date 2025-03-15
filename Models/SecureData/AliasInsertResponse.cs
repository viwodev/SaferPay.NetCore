using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData;

public class AliasInsertResponse : ResponseBase
{
    /// <summary>
    /// Id for referencing later
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Expiration date / time of the generated token in ISO 8601 format in UTC.
    /// </summary>
    public DateTimeOffset Expiration { get; set; }

    /// <summary>
    /// True if a redirect must be performed to continue, false otherwise
    /// </summary>
    public bool RedirectRequired { get; set; }

    /// <summary>
    /// Mandatory if RedirectRequired is true. Contains the URL for the redirect to use for example the Saferpay hosted register form.
    /// </summary>
    public Redirect Redirect { get; set; }
}
