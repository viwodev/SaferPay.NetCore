using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models.Core;

public class Ideal
{
    /// <summary>
    /// Preselect the iDEAL issuer. If specified together with PaymentMethods preselection of iDEAL,<br/>
    /// the user is redirected directly to the issuer bank.<br/>
    /// If the IssuerId is set, it is mandatory to use iDEAL in PaymentMethods.<br/>
    /// </summary>
    public string IssuerId { get; set; }
}
