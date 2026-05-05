namespace SaferPay.Models.Management;

public class CreateSingleUsePaymentLinkResponse : RestResponseBase
{
    public Guid OfferId { get; set; }

    public string PaymentLink { get; set; }
}
