using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData
{
    public class AssertInsertRequest : RequestBase
    {
        /// <summary>
        /// Token returned by initial call.
        /// </summary>
        public string Token { get; set; }
    }
}
