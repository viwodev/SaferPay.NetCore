using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models
{
    public class AuthenticationResult
    {
        /// <summary>
        /// The result of the card holder authentication.<br/><br/>
        /// <i>Possible values: OK, NOT_SUPPORTED.</i>
        /// </summary>
        public AuthenticationResultResult Result { get; set; }

        /// <summary>
        /// More details, if available. Contents may change at any time, so don’t parse it.<br/><br/>
        /// <i>Example: Card holder authentication with 3DSv2 successful.</i>
        /// </summary>
        public string Message { get; set; }
    }

    public enum AuthenticationResultResult
    {
        OK,
        NOT_SUPPORTED
    }
}
