namespace SaferPay.Models.Core
{
    /// <summary>
    /// Twint Data
    /// </summary>
    public class Twint
    {
        /// <summary>
        /// Twint token expiry date<br/><br/>
        /// <i>Example: 2019-11-08T12:29:37.000+01:00</i>
        /// </summary>
        public DateTimeOffset CertificateExpirationDate { get; set; }
    }
}
