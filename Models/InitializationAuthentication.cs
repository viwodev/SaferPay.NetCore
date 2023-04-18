﻿using SaferPay.Enums;

namespace SaferPay.Models
{
    public class InitializationAuthentication
    {
        /// <summary>
        /// Type of Exemption<br/>
        /// <i>Possible values: LOW_VALUE, TRANSACTION_RISK_ANALYSIS.</i>
        /// </summary>
        public ExemptionTypes Exemption { get; set; }

        /// <summary>
        /// 3DS Secure challenge options<br/>
        /// <i>Possible values: AVOID, FORCE.</i>
        /// </summary>
        public ThreeDsChallengeOptionTypes ThreeDsChallenge { get; set; }
    }
}
