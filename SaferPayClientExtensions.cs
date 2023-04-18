using System.Threading.Tasks;
using SaferPay.Models;

namespace SaferPay
{

    /// <summary>
    /// Extensions For SaferPay Transaction Methods
    /// </summary>
	public static class SaferPayClientExtensions
    {

        #region Async Calls

        /// <summary>
        /// This method may be used to start a transaction which may involve either DCC and / or 3d-secure.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<InitializeResponse> InitializeAsync(this ISaferPayClient client, InitializeRequest request)
            => client.SendAsync<InitializeResponse, InitializeRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Initialize", request);

        /// <summary>
        /// This method can be used to start a transaction with the Payment Page which may involve either DCC and / or 3d-secure
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<InitializeResponse> InitializePaymentPageAsync(this ISaferPayClient client, InitializePaymentPageRequest request)
            => client.SendAsync<InitializeResponse, InitializePaymentPageRequest>(SaferPayEndpointConstants.PaymentPageEndpoint + "/Initialize", request);

        /// <summary>
        /// This function may be called to authorize a transaction which was started by a call to Transaction/Initialize.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
		public static Task<AuthorizeResponse> AuthorizeAsync(this ISaferPayClient client, AuthorizeRequest request)
            => client.SendAsync<AuthorizeResponse, AuthorizeRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Authorize", request);

        /// <summary>
        /// This method may be used to finalize previously authorized transactions and refunds.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
		public static Task<CaptureResponse> CaptureAsync(this ISaferPayClient client, CaptureRequest request)
            => client.SendAsync<CaptureResponse, CaptureRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Capture", request);

        /// <summary>
        /// This method may be used to cancel previously authorized transactions and refunds.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
		public static Task<CancelResponse> CancelAsync(this ISaferPayClient client, CancelRequest request)
            => client.SendAsync<CancelResponse, CancelRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Cancel", request);

        /// <summary>
        /// This method may be called to refund a previous transaction.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
		public static Task<RefundResponse> RefundAsync(this ISaferPayClient client, RefundRequest request)
            => client.SendAsync<RefundResponse, RefundRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Refund", request);

        /// <summary>
        /// This method can be used to get the details of a transaction that has been authorized successfully.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<InquireResponse> InquireAsync(this ISaferPayClient client, InquireRequest request)
            => client.SendAsync<InquireResponse, InquireRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Inquire", request);
        #endregion

        #region Sync Calls

        /// <summary>
        /// This method may be used to start a transaction which may involve either DCC and / or 3d-secure.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static InitializeResponse Initialize(this ISaferPayClient client, InitializeRequest request)
            => client.Send<InitializeResponse, InitializeRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Initialize", request);

        /// <summary>
        /// This method can be used to start a transaction with the Payment Page which may involve either DCC and / or 3d-secure
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static InitializeResponse InitializePaymentPage(this ISaferPayClient client, InitializePaymentPageRequest request)
            => client.Send<InitializeResponse, InitializePaymentPageRequest>(SaferPayEndpointConstants.PaymentPageEndpoint + "/Initialize", request);

        /// <summary>
        /// This function may be called to authorize a transaction which was started by a call to Transaction/Initialize.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static AuthorizeResponse Authorize(this ISaferPayClient client, AuthorizeRequest request)
            => client.Send<AuthorizeResponse, AuthorizeRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Authorize", request);

        /// <summary>
        /// This method may be used to finalize previously authorized transactions and refunds.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static CaptureResponse Capture(this ISaferPayClient client, CaptureRequest request)
            => client.Send<CaptureResponse, CaptureRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Capture", request);

        /// <summary>
        /// This method may be used to cancel previously authorized transactions and refunds.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static CancelResponse Cancel(this ISaferPayClient client, CancelRequest request)
            => client.Send<CancelResponse, CancelRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Cancel", request);

        /// <summary>
        /// This method may be called to refund a previous transaction.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static RefundResponse Refund(this ISaferPayClient client, RefundRequest request)
            => client.Send<RefundResponse, RefundRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Refund", request);

        /// <summary>
        /// This method can be used to get the details of a transaction that has been authorized successfully.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static InquireResponse Inquire(this ISaferPayClient client, InquireRequest request)
            => client.Send<InquireResponse, InquireRequest>(SaferPayEndpointConstants.TransactionEndpoint + "/Inquire", request);
        #endregion



    }
}