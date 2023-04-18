namespace SaferPay.Models
{
    public class AuthorizeRequest : RequestBase
    {

        public AuthorizeRequest()
        {            
        }

        /// <summary>
        /// Token returned by Initialize
        /// </summary>
        public string Token { get; set; }

        public AuthorizeRequest(string token)
        {
            Token = token;
        }

        /// <summary>
        /// WITH_LIABILITY_SHIFT: the authorization will be executed if the previous 3d-secure process indicates that the liability shift to the issuer is possible (liability shift may still be declined with the authorization though). This condition will be ignored for brands which Saferpay does not offer 3d-secure for.
        /// <br/>If left out, the authorization will be done if allowed, but possibly without liability shift to the issuer.See the specific result codes in the response message.
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Card verification code if available
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Controls whether the given means of payment should be stored inside the Saferpay Secure Card Data storage.
        /// </summary>
        public RegisterAlias RegisterAlias { get; set; }
    }
}