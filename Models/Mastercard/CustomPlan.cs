using SaferPay.Models.Core;

namespace SaferPay.Models.Mastercard;

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
