using SaferPay.Enums;

namespace SaferPay.Models.Management;

public class TerminalResponse : RestResponseBase
{
    public string Description { get; set; }

    public List<PaymentMethodResponse> PaymentMethods { get; set; }

    public string TerminalId { get; set; }

    public TerminalTypes Type { get; set; }

    public List<Wallet> Wallets { get; set; }
}
