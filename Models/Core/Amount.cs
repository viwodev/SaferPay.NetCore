using SaferPay.Models.Attributes;
using System.Globalization;

namespace SaferPay.Models.Core;

/// <summary>
/// Amount data (currency, value, etc.)
/// </summary>
public class Amount
{

    #region Ctors
    public Amount() { }

    public Amount(decimal amount, string currencyCode)
    {
        CurrencyCode = currencyCode;
        Value = (amount * 100).ToString("n0", new CultureInfo("en-US")).Replace(".", "").Replace(",", "");
    }
    #endregion

    #region Props
    /// <summary>
    /// Amount in minor unit (CHF 1.00 ⇒ Value=100). Only Integer values will be accepted!
    /// </summary>
    [Mandatory("Value field is required.")]
    public string Value { get; set; }

    /// <summary>
    /// ISO 4217 3-letter currency code (CHF, USD, EUR, ...)
    /// </summary>
    [Mandatory("CurrencyCode field is required.")]
    public string CurrencyCode { get; set; }
    #endregion



    public override string ToString()
    {
        decimal money = 0;
        decimal.TryParse(Value, out money);
        return $"{money.ToString("n2")} {CurrencyCode}";
    }
}