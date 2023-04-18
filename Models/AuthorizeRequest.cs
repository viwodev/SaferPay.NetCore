using SaferPay.Enums;

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
        /// WITH_LIABILITY_SHIFT: the authorization will be executed if the previous 3d-secure process indicates that the liability shift to the issuer is possible (liability shift may still be declined with the authorization though). This condition will be ignored for brands which Saferpay does not offer 3d-secure for.<br/>
        /// If left out, the authorization will be done if allowed, but possibly without liability shift to the issuer.See the specific result codes in the response message.<br/><br/>
        /// <i>Possible values: WITH_LIABILITY_SHIFT, IF_ALLOWED_BY_SCHEME.</i><br/>
        /// <i>Example: WITH_LIABILITY_SHIFT</i>
        /// </summary>
        public AuthorizeConditionTypes Condition { get; set; }

        /// <summary>
        /// Card verification code if available<br/><br/>
        /// <i>Numeric[3..4]<br/>
        /// Example: 123</i>
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Controls whether the given means of payment should be stored inside the Saferpay Secure Card Data storage.
        /// </summary>
        public RegisterAlias RegisterAlias { get; set; }

        /// <summary>
        /// Creates An instance of Authorize Request For Given Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static AuthorizeRequest Create(string token)
        {
            return new AuthorizeRequest(token);
        }
    }
}