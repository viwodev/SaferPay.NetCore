using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models
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
        public FraudPreventionResult Result { get; set; }
    }

    /// <summary>
    /// The result of the performed fraud prevention check
    /// </summary>
    public enum FraudPreventionResult
    {
        APPROVED, 
        MANUAL_REVIEW
    }

}
