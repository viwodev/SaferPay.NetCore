using System.Globalization;

namespace SaferPay.Models
{
    public class Amount
    {

        public Amount()
        {
        }

        public Amount(decimal amount, string currencyCode)
        {
            this.CurrencyCode = currencyCode;
            this.Value = (amount * 100).ToString("n0", new CultureInfo("en-US")).Replace(".", "").Replace(",", "");
        }

        public string Value { get; set; }

        public string CurrencyCode { get; set; }

        public override string ToString()
        {
            decimal money = 0;
            decimal.TryParse(Value, out money);
            return $"{money.ToString("n2")} {CurrencyCode}";
        }
    }
}