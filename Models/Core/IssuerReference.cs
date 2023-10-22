namespace SaferPay.Models.Core
{
    /// <summary>
    /// Issuer reference information
    /// </summary>
    public class IssuerReference
    {
        /// <summary>
        /// SCA transaction stamp, created by the card issuer
        /// </summary>
        public string TransactionStamp { get; set; }

        /// <summary>
        /// SCA transaction settlement date, created by the card issuer. For MasterCard schemes only.
        /// </summary>
        public string SettlementDate { get; set; }
    }
}
