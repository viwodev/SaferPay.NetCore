namespace SaferPay.Models
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
            this.Number = number.ToString().Replace(" ","").Trim();
            this.ExpMonth = expMonth;
            this.ExpYear = expYear;

            if (ExpYear.ToString().Length == 2)
            {
                this.ExpYear = 2000 + ExpYear;
            }

            this.VerificationCode = verificationCode;
            this.HolderName = holderName;
        }

        /// <summary>
        /// Card number without separators<br/><br/>
        /// <i>Example: 1234123412341234</i><br></br>
        /// <strong>Mandatory</strong>
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Year of expiration<br/><br/>
        /// <i>Range: inclusive between 2000 and 9999<br/>
        /// Example: 2015</i><br/>
        /// <strong>Mandatory</strong>
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