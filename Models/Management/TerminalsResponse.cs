namespace SaferPay.Models.Management;

public class TerminalsResponse : RestResponseBase
{
    public List<TerminalResponse> Terminals { get; set; }
}
