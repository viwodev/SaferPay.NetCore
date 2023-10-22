namespace SaferPay.Models.Core
{
    /// <summary>
    /// Means of payment (either card data or a reference to a previously stored card). Important: Only fully PCI certified merchants may directly use the card data.If your system is not explicitly certified to handle card data directly, then use the Saferpay Secure Card Data-Storage instead.If the customer enters a new card, you may want to use the Saferpay Hosted Register Form to capture the card data through Saferpay.
    /// </summary>
    public class InitializationPaymentMeans
    {
        public InitializationPaymentMeans() { }
        public InitializationPaymentMeans(Card card) => Card = card;


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
        /// Bank account data for direct debit transaction
        /// </summary>
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// Payment Data from GooglePay
        /// </summary>
        public GooglePay GooglePay { get; set; }

        /// <summary>
        /// Payment Data from ApplePay
        /// </summary>
        public ApplePay ApplePay { get; set; }


    }
}