using SaferPay.Models.Core;

namespace SaferPay.Models.Mastercard
{

    /// <summary>
    /// A maximum number of 12 fixed installment plans<br/>
    /// If InstallmentPlans is present, CustomPlan must not be present
    /// </summary>
    public class InstallmentPlans
    {
        /// <summary>
        /// Number of Installments. Valid values are 2–99.
        /// </summary>
        public int NumberOfInstallments { get; set; }

        /// <summary>
        /// Interest rate in hundredth of a percent. e.g. value 125 means 1.25%.<br/>
        /// Valid values are 0-99999
        /// </summary>
        public string InterestRate { get; set; }

        /// <summary>
        /// Installment Fee
        /// </summary>
        public Amount InstallmentFee { get; set; }

        /// <summary>
        /// Annual percentage rate in hundredth of a percent. e.g. value 125 means 1.25%.<br/>
        /// Valid values are 0-99999
        /// </summary>
        public string AnnualPercentageRate { get; set; }

        /// <summary>
        /// First Installment Amount
        /// </summary>
        public Amount FirstInstallmentAmount { get; set; }

        /// <summary>
        /// Subsequent Installment Amount
        /// </summary>
        public Amount SubsequentInstallmentAmount { get; set; }

        /// <summary>
        /// Total Amount Due
        /// </summary>
        public Amount TotalAmountDue { get; set; }

    }

}
