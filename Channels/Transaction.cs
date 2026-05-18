using SaferPay.Config;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Transaction;

namespace SaferPay.Channels;

public class Transaction : ITransaction
{

    private readonly ISaferPayClient _client;

    public Transaction(SaferPaySettings settings) => _client = new SaferPayClient(settings);
    public Transaction(ISaferPayClient client) => _client = client ?? throw new ArgumentNullException(nameof(client));
    public Transaction(string customerId, string terminalId, string userName, string passWord, bool sandBox = false)
        => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));

    #region Initialize
    public InitializeResponse Initialize(InitializeRequest request) =>
        _client.Send<InitializeResponse, InitializeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInitialize, request);

    public Task<InitializeResponse> InitializeAsync(InitializeRequest request) =>
        _client.SendAsync<InitializeResponse, InitializeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInitialize, request);
    #endregion

    #region Authorize
    public AuthorizeResponse Authorize(AuthorizeRequest request) =>
        _client.Send<AuthorizeResponse, AuthorizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorize, request);

    public Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request) =>
        _client.SendAsync<AuthorizeResponse, AuthorizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorize, request);
    #endregion

    #region AuthorizeDirect
    public AuthorizeDirectResponse AuthorizeDirect(AuthorizeDirectRequest request) =>
        _client.Send<AuthorizeDirectResponse, AuthorizeDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeDirect, request);

    public Task<AuthorizeDirectResponse> AuthorizeDirectAsync(AuthorizeDirectRequest request) =>
        _client.SendAsync<AuthorizeDirectResponse, AuthorizeDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeDirect, request);
    #endregion

    #region AuthorizeReferenced
    public AuthorizeReferencedResponse AuthorizeReferenced(AuthorizeReferencedRequest request) =>
        _client.Send<AuthorizeReferencedResponse, AuthorizeReferencedRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeReferenced, request);

    public Task<AuthorizeReferencedResponse> AuthorizeReferencedAsync(AuthorizeReferencedRequest request) =>
        _client.SendAsync<AuthorizeReferencedResponse, AuthorizeReferencedRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeReferenced, request);
    #endregion

    #region Capture
    public CaptureResponse Capture(CaptureRequest request) =>
        _client.Send<CaptureResponse, CaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCapture, request);

    public Task<CaptureResponse> CaptureAsync(CaptureRequest request) =>
        _client.SendAsync<CaptureResponse, CaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCapture, request);
    #endregion

    #region MultipartCapture
    public MultipartCaptureResponse MultipartCapture(MultipartCaptureRequest request) =>
        _client.Send<MultipartCaptureResponse, MultipartCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartCapture, request);

    public Task<MultipartCaptureResponse> MultipartCaptureAsync(MultipartCaptureRequest request) =>
        _client.SendAsync<MultipartCaptureResponse, MultipartCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartCapture, request);
    #endregion

    #region AssertCapture
    public AssertCaptureResponse AssertCapture(AssertCaptureRequest request) =>
        _client.Send<AssertCaptureResponse, AssertCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertCapture, request);

    public Task<AssertCaptureResponse> AssertCaptureAsync(AssertCaptureRequest request) =>
        _client.SendAsync<AssertCaptureResponse, AssertCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertCapture, request);
    #endregion

    #region MultipartFinalize
    public MultipartFinalizeResponse MultipartFinalize(MultipartFinalizeRequest request) =>
        _client.Send<MultipartFinalizeResponse, MultipartFinalizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartFinalize, request);

    public Task<MultipartFinalizeResponse> MultipartFinalizeAsync(MultipartFinalizeRequest request) =>
        _client.SendAsync<MultipartFinalizeResponse, MultipartFinalizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartFinalize, request);
    #endregion

    #region Refund
    public RefundResponse Refund(RefundRequest request) =>
        _client.Send<RefundResponse, RefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefund, request);

    public Task<RefundResponse> RefundAsync(RefundRequest request) =>
        _client.SendAsync<RefundResponse, RefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefund, request);
    #endregion

    #region AssertRefund
    public AssertRefundResponse AssertRefund(AssertRefundRequest request) =>
        _client.Send<AssertRefundResponse, AssertRefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRefund, request);

    public Task<AssertRefundResponse> AssertRefundAsync(AssertRefundRequest request) =>
        _client.SendAsync<AssertRefundResponse, AssertRefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRefund, request);
    #endregion

    #region RefundDirect
    public RefundDirectResponse RefundDirect(RefundDirectRequest request) =>
        _client.Send<RefundDirectResponse, RefundDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefundDirect, request);

    public Task<RefundDirectResponse> RefundDirectAsync(RefundDirectRequest request) =>
        _client.SendAsync<RefundDirectResponse, RefundDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefundDirect, request);
    #endregion

    #region Cancel
    public CancelResponse Cancel(CancelRequest request) =>
        _client.Send<CancelResponse, CancelRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCancel, request);

    public Task<CancelResponse> CancelAsync(CancelRequest request) =>
        _client.SendAsync<CancelResponse, CancelRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCancel, request);
    #endregion

    #region RedirectPayment
    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public RedirectPaymentResponse RedirectPayment(RedirectPaymentRequest request) =>
        _client.Send<RedirectPaymentResponse, RedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRedirectPayment, request);

    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public Task<RedirectPaymentResponse> RedirectPaymentAsync(RedirectPaymentRequest request) =>
        _client.SendAsync<RedirectPaymentResponse, RedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRedirectPayment, request);
    #endregion

    #region AssertRedirectPayment
    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public AssertRedirectPaymentResponse AssertRedirectPayment(AssertRedirectPaymentRequest request) =>
        _client.Send<AssertRedirectPaymentResponse, AssertRedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRedirectPayment, request);

    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public Task<AssertRedirectPaymentResponse> AssertRedirectPaymentAsync(AssertRedirectPaymentRequest request) =>
        _client.SendAsync<AssertRedirectPaymentResponse, AssertRedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRedirectPayment, request);
    #endregion

    #region Inquire
    public InquireResponse Inquire(InquireRequest request) =>
        _client.Send<InquireResponse, InquireRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInquire, request);

    public Task<InquireResponse> InquireAsync(InquireRequest request) =>
        _client.SendAsync<InquireResponse, InquireRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInquire, request);
    #endregion

    #region AlternativePayment
    public AlternativePaymentResponse AlternativePayment(AlternativePaymentRequest request) =>
        _client.Send<AlternativePaymentResponse, AlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAlternativePayment, request);

    public Task<AlternativePaymentResponse> AlternativePaymentAsync(AlternativePaymentRequest request) =>
        _client.SendAsync<AlternativePaymentResponse, AlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAlternativePayment, request);
    #endregion

    #region QueryAlternativePayment
    public QueryAlternativePaymentResponse QueryAlternativePayment(QueryAlternativePaymentRequest request) =>
        _client.Send<QueryAlternativePaymentResponse, QueryAlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionQueryAlternativePayment, request);

    public Task<QueryAlternativePaymentResponse> QueryAlternativePaymentAsync(QueryAlternativePaymentRequest request) =>
        _client.SendAsync<QueryAlternativePaymentResponse, QueryAlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionQueryAlternativePayment, request);
    #endregion

    #region DccInquiry
    public DccInquiryResponse DccInquire(DccInquiryRequest request) =>
        _client.Send<DccInquiryResponse, DccInquiryRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionDccInquiry, request);

    public Task<DccInquiryResponse> DccInquiryAsync(DccInquiryRequest request) =>
        _client.SendAsync<DccInquiryResponse, DccInquiryRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionDccInquiry, request);
    #endregion

}
