namespace SaferPay.Models
{
    /// <summary>
    /// General information about the request.
    /// </summary>
    public class RequestHeader
    {
        /// <summary>
        /// Version number of the interface specification. For new implementations, the newest Version should be used.
		/// <br/>Possible values: 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 1.10, 1.11, 1.12, 1.13, 1.14, 1.15, 1.16, 1.17, 1.18, 1.19, 1.20, 1.21, 1.22, 1.23, 1.24, 1.25, 1.26, 1.27, 1.28, 1.29, 1.30, 1.31, 1.32, 1.33
        /// </summary>
        public string SpecVersion { get; set; }

        /// <summary>
        /// Saferpay customer id. Part of the Saferpay AccountID, which has the following format: 123123-12345678. The first Value is your CustomerID.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Id generated by merchant system, for debugging purposes. Should be unique for each new request. If a request is retried due to an error, use the same request id. In this case, the RetryIndicator should be increased instead, to indicate a subsequent attempt.
        /// </summary>
		public string RequestId { get; set; }

        /// <summary>
        /// Information about the caller (merchant host)
        /// </summary>
		public ClientInfo ClientInfo { get; set; }

        /// <summary>
        /// 0 if this specific request is attempted for the first time, >=1 if it is a retry.
        /// </summary>
		public int RetryIndicator { get; set; }
    }
}