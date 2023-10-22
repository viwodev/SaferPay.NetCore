using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum WalletTypes
    {
        [Description("Apple Pay")]
        APPLEPAY,

        [Description("Google Pay")]
        GOOGLEPAY
    }
}
