using SaferPay.Models.Core;

namespace SaferPay.Models.Mastercard;

public class MastercardIssuerInstallments
{
    /// <summary>
    /// Installment Payment Data, if applicable
    /// </summary>
    public ChosenPlan ChosenPlan { get; set; }

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
