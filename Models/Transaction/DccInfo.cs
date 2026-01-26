using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class DccInfo
{

    /// <summary>
    /// Brand information
    /// </summary>
    public Brand Brand { get; set; }


    /// <summary>
    /// Amount in payer’s currency
    /// </summary>
    public Amount CardHolderAmount { get; set; }


    /// <summary>
    /// The used exchange rate including markup
    /// The decimal separator used is '.' regardless of location
    /// </summary>
    public string ExchangeRate { get; set; }


    /// <summary>
    /// DCC markup fee
    /// </summary>
    public string Markup { get; set; }


    /// <summary>
    /// Amount in merchant’s currency
    /// </summary>
    public Amount MerchantAmount { get; set; }


    /// <summary>
    /// Source of the exchange rate, according to the source a disclaimer with different requirements must be shown.
    /// </summary>
    public string Source { get; set; }

}
