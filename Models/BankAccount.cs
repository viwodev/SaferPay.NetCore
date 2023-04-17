using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models
{
    public class BankAccount
    {
        /// <summary>
        /// International Bank Account Number in electronical format (without spaces).<br/><br/>
        /// <i>AlphaNumeric[1..50]<br/>
        /// Example: DE12500105170648489890</i>
        /// </summary>
        public string IBAN { get; set; }

        /// <summary>
        /// Name of the account holder.<br/><br/>
        /// <i>Iso885915[1..50]<br/>
        /// Example: John Doe</i>
        /// </summary>
        public string HolderName { get; set; }

        /// <summary>
        /// Bank Identifier Code without spaces.<br/><br/>
        /// <i>AlphaNumeric[8..11]<br/>
        /// Example: INGDDEFFXXX</i>
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// Name of the Bank.
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// ISO 2-letter country code of the IBAN origin (if available)<br/><br/>
        /// <i>Example: CH</i>
        /// </summary>
        public string CountryCode { get; set; }
    }
}
