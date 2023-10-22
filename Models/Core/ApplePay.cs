using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models.Core
{
    /// <summary>
    /// Payment Data from ApplePay
    /// </summary>
    public class ApplePay
    {
        /// <summary>
        /// Base64 encoded ApplePayPaymentToken Json according to Apple's Payment Token Format Reference
        /// </summary>
        public string PaymentToken { get; set; }
    }
}
