using Newtonsoft.Json;
using SaferPay.Enums;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents a payment transaction, including details such as amount, currency, and order ID.
/// </summary>
/// <remarks>
/// The <see cref="Payment"/> class provides constructors for initializing a payment with various formats
/// of amount and currency. It also includes properties for specifying additional payment options, such as recurring or
/// installment plans. Note that recurring options cannot be combined with installment options.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class Payment : BasePayment
{

    #region Ctors
    public Payment() { }

    /// <summary>
    /// Init With Amount, Currency and OrderID
    /// </summary>
    /// <param name="amount">123.45</param>
    /// <param name="currenyCode">ISO 4217 3-letter currency code</param>
    /// <param name="orderId">Order ID</param>
    public Payment(decimal amount, string currenyCode, string orderId)
    {
        OrderId = orderId;
        Amount = new Amount(amount, currenyCode);
    }

    public Payment(decimal amount, CurrencyCodes currenyCode, string orderId)
    {
        OrderId = orderId;
        Amount = new Amount(amount, currenyCode);
    }

    /// <summary>
    /// Init With Amount, Currency and OrderID
    /// </summary>
    /// <param name="amount">12345 for 123.45</param>
    /// <param name="currenyCode">ISO 4217 3-letter currency code</param>
    /// <param name="orderId">Order ID</param>
    public Payment(string amount, string currenyCode, string orderId)
    {
        OrderId = orderId;
        var value = amount.Replace(" ", "").Replace(",", "").Replace(".", "");
        this.Amount = new Amount();
        this.Amount.Value = value;
        this.Amount.CurrencyCode = currenyCode;
    }
    #endregion

    #region Props
    /// <summary>
    /// Specific payment options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public PaymentOptions Options { get; set; }

    /// <summary>
    /// Recurring options – cannot be combined with Installment.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public RecurringOptions Recurring { get; set; }

    /// <summary>
    /// Installment options – cannot be combined with Recurring.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public InstallmentOptions Installment { get; set; }
    #endregion

}