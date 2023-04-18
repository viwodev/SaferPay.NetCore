namespace SaferPay.Models
{
    public class RegistrationResult
    {
        /// <summary>
        /// Result of registration<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// If Success is 'true', information about the alias
        /// </summary>
		public Alias Alias { get; set; }

        /// <summary>
        /// If Success is 'false', information on why the registration failed
        /// </summary>
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// contains information whether the alias is saved with the strong authentication details or not.
        /// </summary>
        public AuthenticationResult AuthenticationResult { get; set; }
    }
}