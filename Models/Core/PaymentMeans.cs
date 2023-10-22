namespace SaferPay.Models.Core
{
    /// <summary>
    /// Information about the means of payment
    /// </summary>
    public class PaymentMeans
    {

        public PaymentMeans() { }
        public PaymentMeans(Card card) => Card = card;
        public PaymentMeans(ApplePay applePay) => ApplePay = applePay;

        public PaymentMeans(BankAccount bankAccount) => BankAccount = bankAccount;

        public PaymentMeans(Alias alias) => Alias = alias;

        public PaymentMeans(PayPal payPal) => PayPal = payPal;

        public PaymentMeans(GooglePay googlePay) => GooglePay = googlePay;

        public PaymentMeans(Twint twint) => Twint = twint;

        /// <summary>
        /// Brand information
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// Means of payment formatted / masked for display purposes
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Name of Wallet, if the transaction was done by a wallet
        /// </summary>
        public string Wallet { get; set; }

        /// <summary>
        /// Payment means data collected with SaferpayFields.
        /// </summary>
        public SaferpayFields SaferpayFields { get; set; }

        /// <summary>
        /// Card data
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Alias data if payment means was registered with Secure Card Data before.
        /// </summary>
        public Alias Alias { get; set; }

        /// <summary>
        /// Surrogate values that replace the primary account number (PAN) according to the EMV Payment Tokenization Specification
        /// </summary>
        public SchemeToken SchemeToken { get; set; }

        /// <summary>
        /// Bank account data for direct debit transactions.
        /// </summary>
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// PayPal data
        /// </summary>
        public PayPal PayPal { get; set; }

        /// <summary>
        /// Twint data
        /// </summary>
        public Twint Twint { get; set; }

        /// <summary>
        /// Payment Data from GooglePay
        /// </summary>
        public GooglePay GooglePay { get; set; }

        /// <summary>
        /// Payment Data from ApplePay
        /// </summary>
        public ApplePay ApplePay { get; set; }

        public static implicit operator PaymentMeans(Card v)
        {
            return new PaymentMeans(v);
        }

        public static implicit operator PaymentMeans(ApplePay v)
        {
            return new PaymentMeans(v);
        }

        public static implicit operator PaymentMeans(BankAccount v)
        {
            return new PaymentMeans(v);
        }

        public static implicit operator PaymentMeans(PayPal v)
        {
            return new PaymentMeans(v);
        }

        public static implicit operator PaymentMeans(GooglePay v)
        {
            return new PaymentMeans(v);
        }

        public static implicit operator PaymentMeans(Twint v)
        {
            return new PaymentMeans(v);
        }

        public static implicit operator PaymentMeans(Alias v)
        {
            return new PaymentMeans(v);
        }
    }
}
