using SaferPay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models.Core
{
    public class CardForm
    {
        /// <summary>
        /// This parameter lets you customize the holder name field on the card entry form. Per default, a holder name field is not shown.<br/><br/>
        /// <i>Possible values: NONE, MANDATORY.</i>
        /// </summary>
        public HolderNameTypes HolderName { get; set; }

        /// <summary>
        /// This parameter can be used to display an entry form to request Verification Code (CVV, CVC) in case that an alias is used as PaymentMeans. Note that not all brands support Verification Code.<br/><br/>
        /// <i>Possible values: NONE, MANDATORY.</i>
        /// </summary>
        public VerificationCodeTypes VerificationCode { get; set; }
    }
}
