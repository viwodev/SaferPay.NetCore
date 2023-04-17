﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models
{
    /// <summary>
    /// LiabilityShift information, replaces ThreeDs Info from api version 1.8
    /// </summary>
    public class Liability
    {
        /// <summary>
        /// Is liability shifted for this transaction<br/><br/>
        /// </summary>
        public bool LiabilityShift { get; set; }

        /// <summary>
        /// Indicates who takes the liability for the transaction<br/><br/>
        /// <i>Possible values: MERCHANT, THREEDS.</i>
        /// </summary>
        public LiableEntityType LiableEntity { get; set; }

        /// <summary>
        /// Details about ThreeDs if applicable<br/><br/>
        /// </summary>
        public ThreeDs ThreeDs { get; set; }

        /// <summary>
        /// Determines if the transaction is in the PSD2 Scope (Payment Service Directive 2 of the European Union)<br/><br/>
        /// <i>Possible values: YES, NO, UNKNOWN.</i>
        /// </summary>
        public InPsd2ScopeType InPsd2Scope { get; set; }

    }

    /// <summary>
    /// Determines if the transaction is in the PSD2 Scope (Payment Service Directive 2 of the European Union)
    /// </summary>
    public enum InPsd2ScopeType
    {
        YES,
        NO,
        UNKNOWN
    }

    /// <summary>
    /// Indicates who takes the liability for the transaction
    /// </summary>
    public enum LiableEntityType
    {
        MERCHANT,
        THREEDS
    }
}
