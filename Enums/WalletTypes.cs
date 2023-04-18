using System.ComponentModel;

namespace SaferPay.Enums
{
    public enum WalletTypes
    {
        [Description("MasterPass")]
        MASTERPASS,

        [Description("Apple Pay")]
        APPLEPAY,

        [Description("Google Pay")]
        GOOGLEPAY
    }
}
