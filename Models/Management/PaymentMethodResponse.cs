using SaferPay.Enums;

namespace SaferPay.Models.Management;

public class PaymentMethodResponse
{
    public PaymentMethodTypes PaymentMethod { get; set; }

    public List<CurrencyCodes> Currencies { get; set; }

    public string LogoUrl { get; set; }
}
