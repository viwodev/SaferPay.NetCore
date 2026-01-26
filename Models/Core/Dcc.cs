using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

/// <summary>
/// Dcc information, if applicable
/// </summary>
public class Dcc
{

    /// <summary>
    /// Currency selected by the payer
    /// </summary>
    [Mandatory("SelectedCurrencyCode is mandatory!")]
    public string SelectedCurrencyCode { get; set; }


    /// <summary>
    /// The used exchange rate including markup<br/>
    /// The decimal separator used is '.' regardless of location<br/><br/>
    /// <i>Example: 1.2345</i>
    /// </summary>
    public string ExchangeRate { get; set; }


    /// <summary>
    /// DCC markup fee<br/><br/>
    /// <i>Example: 3%</i>
    /// </summary>
    public string Markup { get; set; }


    /// <summary>
    /// Amount in payer’s currency
    /// </summary>
    public Amount PaymentAmount { get; set; }


    /// <summary>
    /// Token from DCC Inquiry response
    /// </summary>
    [Mandatory("Token is mandatory!")]
    public string Token { get; set; }


}