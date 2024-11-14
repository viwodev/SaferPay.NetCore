namespace SaferPay.Models.Core;

public class Marketplace
{
    public Amount Fee { get; set; }

    public Amount FeeRefund { get; set; }

    public string SubmerchantId { get; set; }
}
