using SaferPay.Models.Core;

namespace SaferPay.Models.PaymentPage
{
    public class AssertRequest : RequestBase
    {

        public AssertRequest() { }
        public AssertRequest(String token) { Token = token; }

        /// <summary>
        /// Token returned by initial call.
        /// </summary>
        public string Token { get; set; }
    }
}
