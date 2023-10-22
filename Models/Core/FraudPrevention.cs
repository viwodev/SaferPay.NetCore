using SaferPay.Enums;

namespace SaferPay.Models.Core
{
    /// <summary>
    /// Contains details of a performed fraud prevention check
    /// </summary>
    public class FraudPrevention
    {
        /// <summary>
        /// The result of the performed fraud prevention check<br/><br/>
        /// <i>Possible values: APPROVED, MANUAL_REVIEW.<br/>
        /// Example: APPROVED</i>
        /// </summary>
        public FraudPreventionResultTypes Result { get; set; }
    }

}
