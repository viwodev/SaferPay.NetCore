namespace SaferPay.Models.Core
{
    /// <summary>
    /// Recurring options – cannot be combined with Installment.
    /// </summary>
    public class RecurringOptions
    {
        /// <summary>
        /// <b>Initial <i>![Mandatory]</i></b><br/><br/>
        /// If set to true, the authorization may later be referenced for recurring followup transactions.
        /// </summary>
        public bool Initial { get; set; }
    }
}