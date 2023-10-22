using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class QueryAlternativePaymentRequest : RequestBase
    {

        public QueryAlternativePaymentRequest()
        {            
        }

        public QueryAlternativePaymentRequest(string token)
        {
            this.Token = token;
        }

        public string Token { get; set; }
    }
}
