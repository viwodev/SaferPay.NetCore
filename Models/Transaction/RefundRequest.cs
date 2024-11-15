using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class RefundRequest : RequestBase
{

    #region Ctors
    public RefundRequest() { }

    public RefundRequest(string transactionId, decimal amount, string currency)
    {
        this.Refund = new Refund();
        this.Refund.Amount = new Amount(amount, currency);

        this.CaptureReference = new TransactionReference();
        this.CaptureReference.TransactionId = transactionId;
    }

    public RefundRequest(string transactionId, string amount, string currency)
    {
        this.Refund = new Refund();
        this.Refund.Amount = new Amount();
        this.Refund.Amount.CurrencyCode = currency;
        this.Refund.Amount.Value = amount;

        this.CaptureReference = new TransactionReference();
        this.CaptureReference.TransactionId = transactionId;
    }
    #endregion

    #region Props
    /// <summary>
    /// Reference to the capture you want to refund.
    /// </summary>
    public TransactionReference CaptureReference { get; set; }

    /// <summary>
    /// PaymentMethodsOptions
    /// </summary>
    public PaymentMethodsOptions PaymentMethodsOptions { get; set; }

    /// <summary>
    /// Optional pending notification options
    /// </summary>
    public Notification PendingNotification { get; set; }

    /// <summary>
    /// Information about the refund (amount, currency, ...)
    /// </summary>
    public Refund Refund { get; set; }
    #endregion


}