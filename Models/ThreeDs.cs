using SaferPay.Enums;

namespace SaferPay.Models
{
    public class ThreeDs
    {
        /// <summary>
        /// Indicates, whether the payer has successfuly authenticated him/herself or not.<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public bool Authenticated { get; set; }

        /// <summary>
        /// Indicates whether liability shift to issuer is possible or not. Not present if PaymentMeans container was not present in Initialize request. True, if liability shift to issuer is possible, false if not (only SSL transaction).<br/>
        /// Please note, that the authentification can be true, but the liabilityshift is false. The issuer has the right to deny the liabiliy shift during the authorization.You can continue to capture the payment here, but we recommend to cancel unsecure payments.<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public bool LiabilityShift { get; set; }

        /// <summary>
        /// Transaction Id, given by the MPI. References the 3D Secure process.<br/><br/>
        /// <i>Example: ARkvCgk5Y1t/BDFFXkUPGX9DUgs= for 3D Secure version 1 /<br/>
        /// 1ef5b3db-3b97-47df-8272-320d0bd18ab5 for 3D Secure version 2
        /// </i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public string Xid { get; set; }

        /// <summary>
        /// The 3D Secure Version.<br/><br/>
        /// <i>Example: 2</i>
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Determines how the card holder was authenticated. Some 3D Secure Versions allow a Frictionless authentication.<br/><br/>
        /// <i>Possible values: STRONG_CUSTOMER_AUTHENTICATION, FRICTIONLESS, ATTEMPT, EXEMPTION, NONE.<br/>
        /// Example: StrongCustomerAuthentication</i>
        /// </summary>
        public AuthenticationTypes AuthenticationType { get; set; }

    }

}