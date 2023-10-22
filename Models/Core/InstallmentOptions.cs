namespace SaferPay.Models.Core
{
    /// <summary>
    /// Installment options – cannot be combined with Recurring.
    /// </summary>
    public class InstallmentOptions
    {
        /// <summary>
        /// <b>Initial <i>![Mandatory]</i></b><br/><br/>
        /// If set to true, the authorization may later be referenced for installment followup transactions.
        /// </summary>
        public bool Initial { get; set; }
    }
}
