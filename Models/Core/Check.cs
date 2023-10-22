using SaferPay.Enums;

namespace SaferPay.Models.Core
{
    public class Check
    {
        public CheckTypes Type { get; set; }

        public string TerminalId { get; set; }
    }
}
