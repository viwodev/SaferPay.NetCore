using SaferPay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models.Core
{
    /// <summary>
    /// Styling options
    /// </summary>
    public class StylingOptions
    {
        /// <summary>
        /// This parameter let you customize the appearance of the displayed payment pages. Per default a lightweight responsive styling will be applied. If you don't want any styling use 'NONE'.
        /// <br/><br/><i>
        /// Possible values: DEFAULT, SIX, NONE.<br/>
        /// Example: DEFAULT
        /// </i>
        /// </summary>
        public ThemeTypes Theme { get; set; }

        /// <summary>
        /// Custom styling resource (url) which will be referenced in web pages displayed by Saferpay to apply your custom styling. This file must be hosted on a SSL/TLS secured web server(the url must start with https://). If a custom CSS is provided, any design related settings set in the payment page config (PPConfig) will be ignored and the default design will be used.
        /// <br/><br/><i>Max length: 2000</i><br/>
        /// Example: https://merchanthost/merchant.css
        /// </summary>
        public string CssUrl { get; set; }

        /// <summary>
        /// When enabled, then ContentSecurity/SAQ-A is requested, which leads to the CSS being loaded from the saferpay server.
        /// </summary>
        public bool ContentSecurityEnabled { get; set; }
    }
}
