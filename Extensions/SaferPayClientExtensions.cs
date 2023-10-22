using SaferPay.Interfaces;
using SaferPay.Models.PaymentPage;
using SaferPay.Models.Transaction;

namespace SaferPay
{

    /// <summary>
    /// Extensions For SaferPay Transaction Methods
    /// </summary>
	public static class SaferPayClientExtensions
    {

        #region Payment Page Sync Extensions
        /// <summary>
        /// Initialize Payment Page
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static InitializePaymentPageResponse InitializePaymentPage(this ISaferPayClient client, InitializePaymentPageRequest request) => client.PaymentPage.Initialize(request);

        /// <summary>
        /// Assert Payment Page
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static AssertResponse AssertPaymentPage(this ISaferPayClient client, AssertRequest request) => client.PaymentPage.Assert(request);
        #endregion

        #region Payment Page AsyncSync Extensions
        /// <summary>
        /// Initialize Payment Page <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<InitializePaymentPageResponse> InitializePaymentPageAsync(this ISaferPayClient client, InitializePaymentPageRequest request) => client.PaymentPage.InitializeAsync(request);

        /// <summary>
        /// Assert Payment Page <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<AssertResponse> AssertPaymentPageAsync(this ISaferPayClient client, AssertRequest request) => client.PaymentPage.AssertAsync(request);
        #endregion

        #region Transaction Sync Extensions
        /// <summary>
        /// Initialize Transaction
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static InitializeResponse InitializeTransaction(this ISaferPayClient client, InitializeRequest request) => client.Transaction.Initialize(request);

        /// <summary>
        /// Authorize Transaction
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static AuthorizeResponse Authorize(this ISaferPayClient client, AuthorizeRequest request) => client.Transaction.Authorize(request);

        /// <summary>
        /// Capture Transaction
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static CaptureResponse Capture(this ISaferPayClient client, CaptureRequest request) => client.Transaction.Capture(request);

        /// <summary>
        /// Cancel Transaction
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static CancelResponse Cancel(this ISaferPayClient client, CancelRequest request) => client.Transaction.Cancel(request);

        /// <summary>
        /// Refund Transaction
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static RefundResponse Refund(this ISaferPayClient client, RefundRequest request) => client.Transaction.Refund(request);

        /// <summary>
        /// Inquiry Transaction
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static InquireResponse Inquiry(this ISaferPayClient client, InquireRequest request) => client.Transaction.Inquire(request);
        #endregion

        #region Transaction Async Extensions
        /// <summary>
        /// Initialize Transaction <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<InitializeResponse> InitializeTransactionAsync(this ISaferPayClient client, InitializeRequest request) => client.Transaction.InitializeAsync(request);

        /// <summary>
        /// Authorize Transaction <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<AuthorizeResponse> AuthorizeAsync(this ISaferPayClient client, AuthorizeRequest request) => client.Transaction.AuthorizeAsync(request);

        /// <summary>
        /// Capture Transaction <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<CaptureResponse> CaptureAsync(this ISaferPayClient client, CaptureRequest request) => client.Transaction.CaptureAsync(request);

        /// <summary>
        /// Cancel Transaction <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<CancelResponse> CancelAsync(this ISaferPayClient client, CancelRequest request) => client.Transaction.CancelAsync(request);

        /// <summary>
        /// Refund Transaction <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<RefundResponse> RefundAsync(this ISaferPayClient client, RefundRequest request) => client.Transaction.RefundAsync(request);

        /// <summary>
        /// Inquiry Transaction <i>(Async)</i>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<InquireResponse> InquiryAsync(this ISaferPayClient client, InquireRequest request) => client.Transaction.InquireAsync(request);
        #endregion
    }
}