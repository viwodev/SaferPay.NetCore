using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class AdjustAmountRequest : RequestBase
    {

        public AdjustAmountRequest()
        {
            
        }

        public AdjustAmountRequest(string token)
        {
            this.Token = token;
        }

        public AdjustAmountRequest(string token, Amount amount)
        {
            this.Token = token;
            this.Amount = amount;
        }

        public AdjustAmountRequest(string token, decimal amount, string currency)
        {
            this.Token = token;
            this.Amount = new Amount(amount, currency);
        }

        /// <summary>
        /// Token returned by Initialize
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The new amount
        /// </summary>
        public Amount Amount { get; set; }
    }
}
