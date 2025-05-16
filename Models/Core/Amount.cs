using SaferPay.Enums;
using SaferPay.Models.Attributes;
using System.Globalization;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents a monetary amount with a value in minor units and an associated currency code.
/// </summary>
/// <remarks>
/// The <see cref="Amount"/> class is used to handle monetary values in their minor unit representation.
/// For example, an amount of 1.00 in CHF would be represented as 100 in the <see cref="Value"/> property. The currency
/// is specified using the ISO 4217 3-letter currency code.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class Amount
{

    #region Ctors
    public Amount() { }

    public Amount(decimal amount, string currencyCode)
    {
        CurrencyCode = currencyCode;
        Value = (amount * 100).ToString("n0", new CultureInfo("en-US")).Replace(".", "").Replace(",", "");
    }

    public Amount(decimal amount, CurrencyCodes currencyCode)
    {
        CurrencyCode = currencyCode.ToString().ToUpper();
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