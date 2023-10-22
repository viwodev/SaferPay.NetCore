namespace SaferPay.Models.Core
{
    /// <summary>
    /// Card data
    /// </summary>
    public class InitializationCard
    {

        public InitializationCard()
        {
        }

        public InitializationCard(string number, int expMonth, int expYear, string verificationCode = "", string holderName = "")
        {
            Number = number.ToString().Replace(" ", "").Trim();
            ExpMonth = expMonth;
            ExpYear = expYear;

            if (ExpYear.ToString().Length == 2)
            {
                ExpYear = 2000 + ExpYear;
            }

            VerificationCode = verificationCode;
            HolderName = holderName;
        }

        /// <summary>
        /// <b>Number <i>![Mandatory]</i></b><br/><br/>
        /// Card number without separators<br/><br/>
        /// <i>Example: 1234123412341234</i><br></br>
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// <b>ExpYear <i>![Mandatory]</i></b><br/><br/>
        /// Year of expiration<br/><br/>
        /// <i>Range: inclusive between 2000 and 9999<br/>
        /// Example: 2015</i><br/>
        /// </summary>
		public int ExpYear
        {
            get
            {
                return mExpYear;
            }

            set
            {
                if (value.ToString().Length == 2)
                {
                    mExpYear = 2000 + value;
                }
                else
                {
                    mExpYear = value;
                }
            }
        }
        private int mExpYear;

        /// <summary>
        /// <b>ExpMonth <i>![Mandatory]</i></b>
        /// Month of expiration (eg 9 for September)<br/><br/>
        /// <i>Range: inclusive between 1 and 12<br/>
        /// Example: 9</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public int ExpMonth { get; set; }

        /// <summary>
        /// Name of the card holder<br/><br/>
        /// <i>Utf8[1..50]<br/>
        /// Example: John Doe</i>
        /// </summary>
		public string HolderName { get; set; }

        /// <summary>
        /// Verification code (CVV, CVC) if applicable<br/><br/>
        /// <i>Numeric[3..4]<br/>
        /// Example: 123</i>
        /// </summary>
		public string VerificationCode { get; set; }
    }
}