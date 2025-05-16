using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents a return URL used to redirect after a successful, failed, or aborted transaction."
/// </summary>
/// <remarks>
/// This class encapsulates a URI that is mandatory for transaction redirection scenarios.  It provides
/// constructors for initializing the URL and supports implicit conversion from a string.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class ReturnUrl
{
    public ReturnUrl() { }

    public ReturnUrl(string url) => Url = new Uri(url);

    public ReturnUrl(Uri url) => Url = url;


    /// <summary>
    /// Return url for successful, failed or aborted transaction<br/><br/>
    /// <strong>Mandatory</strong>
    /// </summary>
    /// <remarks>
    /// <i>Max length: 2000</i><br/>
    /// <i>Example: https://merchanthost/return</i>
    /// </remarks>
    [Mandatory("Url field is mandatory.")]
    public Uri Url { get; set; }


    public override string ToString() => Url.ToString();


    public static implicit operator ReturnUrl(string url) => new ReturnUrl(url);


    public static explicit operator string(ReturnUrl returnUrl) => returnUrl.Url.ToString();


}
