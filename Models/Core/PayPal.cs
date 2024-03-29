﻿using SaferPay.Enums;

namespace SaferPay.Models.Core
{
    public class PayPal
    {
        /// <summary>
        /// PayerId from PayPal<br/><br/>
        /// <i>Example: 5b9aefc5-9b48-4a95-ae47-cda20420d68e</i>
        /// </summary>
        public string PayerId { get; set; }

        /// <summary>
        /// Seller protection status from PayPal.<br/><br/>
        /// <i>Possible values: ELIGIBLE, PARTIALLY_ELIGIBLE, NOT_ELIGIBLE.<br/>
        /// Example: ELIGIBLE</i>
        /// </summary>
        public SellerProtectionStatusTypes SellerProtectionStatus { get; set; }

        /// <summary>
        /// The email address used in PayPal<br/><br/>
        /// <i></i>
        /// </summary>
        public string Email { get; set; }
    }


}
