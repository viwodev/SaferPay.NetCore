namespace SaferPay.Config
{
    public static class SaferPayEndpoints
    {
        /// <summary>
        /// Version
        /// </summary>
        public const string Version = "v1";

        /// <summary>
        /// Transaction Base Endpoint
        /// </summary>
        public const string TransactionEndpoint = "Payment/" + Version + "/Transaction/";

        /// <summary>
        /// PaymentPage Base Endpoint
        /// </summary>
        public const string PaymentPageEndpoint = "Payment/" + Version + "/PaymentPage/";

        /// <summary>
        /// Secure Card Data Base Endpoint
        /// </summary>
        public const string AliasEndpoint = "Payment/" + Version + "/Alias/";

        /// <summary>
        /// Batch Base Endpoint
        /// </summary>
        public const string BatchEndpoint = "Payment/" + Version + "/Batch/";

        /// <summary>
        /// OmniChannel
        /// </summary>
        public const string OmniChannelEndpoint = "Payment/" + Version + "/OmniChannel/";
    }
}
