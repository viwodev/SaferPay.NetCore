using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models
{
    public class MastercardIssuerInstallments
    {
        /// <summary>
        /// A maximum number of 12 fixed installment plans<br/>
        /// If InstallmentPlans is present, CustomPlan must not be present
        /// </summary>
        public InstallmentPlans InstallmentPlans { get; set; }

        /// <summary>
        /// An installment plan with customizable numbers of installments<br/>
        /// If CustomPlan is present, InstallmentPlans must not be present<br/><br/>
        /// An installment plan with customizable numbers of installments
        /// </summary>
        public CustomPlan CustomPlan { get; set; }

        /// <summary>
        /// Receipt Free Text
        /// </summary>
        public string ReceiptFreeText { get; set; }
    }

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

    /// <summary>
    /// An installment plan with customizable numbers of installments<br/>
    /// If CustomPlan is present, InstallmentPlans must not be present<br/><br/>
    /// An installment plan with customizable numbers of installments
    /// </summary>
    public class CustomPlan
    {

        /// <summary>
        /// Minimum Number of Installments. Valid values are 2–99 and<br/>
        /// MinimumNumberOfInstallments must be smaller or equal MaximumNumberOfInstallments.
        /// </summary>
        public int MinimumNumberOfInstallments { get; set; }

        /// <summary>
        /// Maximum Number of Installments. Valid values are 2–99 and<br/>
        /// MaximumNumberOfInstallments must be bigger or equal MinimumNumberOfInstallments.
        /// </summary>
        public int MaximumNumberOfInstallments { get; set; }

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
        /// Annual percentage rate in hundreth of a percent. e.g. value 125 means 1.25%.<br/>
        /// Valid values are 0-99999
        /// </summary>
        public string AnnualPercentageRate { get; set; }

        /// <summary>
        /// Total Amount Due
        /// </summary>
        public Amount TotalAmountDue { get; set; }
    }
}
