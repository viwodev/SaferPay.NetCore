using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Models.Management;

public class SingleUsePaymentLinkResponse : RestResponseBase
{
    public DateTime CreationDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public Guid OfferId { get; set; }

    public BasePayment Payment { get; set; }

    public string PaymentLink { get; set; }

    public SecurePayGateOfferStatus Status { get; set; }

    public string TransactionId { get; set; }
}
