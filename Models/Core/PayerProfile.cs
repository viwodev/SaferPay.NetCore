using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models.Core
{
    public class PayerProfile
    {
        /// <summary>
        /// Does the payer have an account in the shop?
        /// </summary>
        public bool HasAccount { get; set; }

        /// <summary>
        /// Does the payer have a password?
        /// </summary>
        public bool HasPassword { get; set; }

        /// <summary>
        /// Was the password reset by the payer using the "forgot my password" feature in the current session?
        /// </summary>
        public bool PasswordForgotten { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string DateOfBirth { get; set; }

        public string Email { get; set; }

        public string SecondaryEmail { get; set; }

        public string Phone { get; set; }

    }
}
