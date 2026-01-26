using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction;

public class RefundDirectRequest : RequestBase
{

    /// <summary>
    /// Information about the Original Credit Transfer like the Address of the Recipient.
    /// </summary>
    public OriginalCreditTransfer OriginalCreditTransfer { get; set; }

    /// <summary>
    /// Information on the means of payment. Important: Only fully PCI certified merchants may directly use the card data.<br/>
    /// If your system is not explicitly certified to handle card data directly, then use the Saferpay Secure Card Data-Storage instead.<br/>
    /// If the customer enters a new card, you may want to use the Saferpay Hosted Register Form to capture the card data through Saferpay.
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }


    /// <summary>
    /// Information about the refund (amount, currency, ...)
    /// </summary>
    public Refund Refund { get; set; }

    /// <summary>
    /// Saferpay Terminal-Id
    /// </summary>
    public string TerminalId { get; set; }


}
