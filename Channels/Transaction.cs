using SaferPay.Config;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Transaction;

namespace SaferPay.Channels;

public class Transaction : ITransaction
{

    private readonly ISaferPayClient _client;

    public Transaction(SaferPaySettings settings) => _client = new SaferPayClient(settings);
    public Transaction(ISaferPayClient client) => _client = client;
    public Transaction(string customerId, string terminalId, string userName, string passWord, bool sandBox = false) => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));

    #region Initialize
    public InitializeResponse Initialize(InitializeRequest request)
    {
        if (_client != null) return _client.Send<InitializeResponse, InitializeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInitialize, request);
        return null;
    }

    public Task<InitializeResponse> InitializeAsync(InitializeRequest request)
    {
        if (_client != null) return _client.SendAsync<InitializeResponse, InitializeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInitialize, request);
        return null;
    }
    #endregion

    #region Authorize 
    public AuthorizeResponse Authorize(AuthorizeRequest request)
    {
        if (_client != null) return _client.Send<AuthorizeResponse, AuthorizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorize, request);
        return null;
    }

    public Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request)
    {
        if (_client != null) return _client.SendAsync<AuthorizeResponse, AuthorizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorize, request);
        return null;
    }
    #endregion

    #region AuthorizeDirect 
    public AuthorizeDirectResponse AuthorizeDirect(AuthorizeDirectRequest request)
    {
        if (_client != null) return _client.Send<AuthorizeDirectResponse, AuthorizeDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeDirect, request);
        return null;
    }

    public Task<AuthorizeDirectResponse> AuthorizeDirectAsync(AuthorizeDirectRequest request)
    {
        if (_client != null) return _client.SendAsync<AuthorizeDirectResponse, AuthorizeDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeDirect, request);
        return null;
    }
    #endregion

    #region AuthorizeReferenced 
    public AuthorizeReferencedResponse AuthorizeReferenced(AuthorizeReferencedRequest request)
    {
        if (_client != null) return _client.Send<AuthorizeReferencedResponse, AuthorizeReferencedRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeReferenced, request);
        return null;
    }

    public Task<AuthorizeReferencedResponse> AuthorizeReferencedAsync(AuthorizeReferencedRequest request)
    {
        if (_client != null) return _client.SendAsync<AuthorizeReferencedResponse, AuthorizeReferencedRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAuthorizeReferenced, request);
        return null;
    }
    #endregion

    #region Capture
    public CaptureResponse Capture(CaptureRequest request)
    {
        if (_client != null) return _client.Send<CaptureResponse, CaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCapture, request);
        return null;
    }

    public Task<CaptureResponse> CaptureAsync(CaptureRequest request)
    {
        if (_client != null) return _client.SendAsync<CaptureResponse, CaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCapture, request);
        return null;
    }
    #endregion

    #region MultipartCapture 
    public MultipartCaptureResponse MultipartCapture(MultipartCaptureRequest request)
    {
        if (_client != null) return _client.Send<MultipartCaptureResponse, MultipartCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartCapture, request);
        return null;
    }

    public Task<MultipartCaptureResponse> MultipartCaptureAsync(MultipartCaptureRequest request)
    {
        if (_client != null) return _client.SendAsync<MultipartCaptureResponse, MultipartCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartCapture, request);
        return null;
    }
    #endregion

    #region AssertCapture 
    public AssertCaptureResponse AssertCapture(AssertCaptureRequest request)
    {
        if (_client != null) return _client.Send<AssertCaptureResponse, AssertCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertCapture, request);
        return null;
    }

    public Task<AssertCaptureResponse> AssertCaptureAsync(AssertCaptureRequest request)
    {
        if (_client != null) return _client.SendAsync<AssertCaptureResponse, AssertCaptureRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertCapture, request);
        return null;
    }
    #endregion

    #region MultipartFinalize 
    public MultipartFinalizeResponse MultipartFinalize(MultipartFinalizeRequest request)
    {
        if (_client != null) return _client.Send<MultipartFinalizeResponse, MultipartFinalizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartFinalize, request);
        return null;
    }

    public Task<MultipartFinalizeResponse> MultipartFinalizeAsync(MultipartFinalizeRequest request)
    {
        if (_client != null) return _client.SendAsync<MultipartFinalizeResponse, MultipartFinalizeRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionMultipartFinalize, request);
        return null;
    }
    #endregion

    #region Refund 
    public RefundResponse Refund(RefundRequest request)
    {
        if (_client != null) return _client.Send<RefundResponse, RefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefund, request);
        return null;
    }

    public Task<RefundResponse> RefundAsync(RefundRequest request)
    {
        if (_client != null) return _client.SendAsync<RefundResponse, RefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefund, request);
        return null;
    }
    #endregion

    #region AssertRefund 
    public AssertRefundResponse AssertRefund(AssertRefundRequest request)
    {
        if (_client != null) return _client.Send<AssertRefundResponse, AssertRefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRefund, request);
        return null;
    }

    public Task<AssertRefundResponse> AssertRefundAsync(AssertRefundRequest request)
    {
        if (_client != null) return _client.SendAsync<AssertRefundResponse, AssertRefundRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRefund, request);
        return null;
    }
    #endregion

    #region RefundDirect 
    public RefundDirectResponse RefundDirect(RefundDirectRequest request)
    {
        if (_client != null) return _client.Send<RefundDirectResponse, RefundDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefundDirect, request);
        return null;
    }

    public Task<RefundDirectResponse> RefundDirectAsync(RefundDirectRequest request)
    {
        if (_client != null) return _client.SendAsync<RefundDirectResponse, RefundDirectRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRefundDirect, request);
        return null;
    }
    #endregion

    #region Cancel
    public CancelResponse Cancel(CancelRequest request)
    {
        if (_client != null) return _client.Send<CancelResponse, CancelRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCancel, request);
        return null;
    }

    public Task<CancelResponse> CancelAsync(CancelRequest request)
    {
        if (_client != null) return _client.SendAsync<CancelResponse, CancelRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionCancel, request);
        return null;
    }
    #endregion

    #region RedirectPayment 
    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public RedirectPaymentResponse RedirectPayment(RedirectPaymentRequest request)
    {
        if (_client != null) return _client.Send<RedirectPaymentResponse, RedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRedirectPayment, request);
        return null;
    }

    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public Task<RedirectPaymentResponse> RedirectPaymentAsync(RedirectPaymentRequest request)
    {
        if (_client != null) return _client.SendAsync<RedirectPaymentResponse, RedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionRedirectPayment, request);
        return null;
    }
    #endregion

    #region AssertRedirectPayment 
    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public AssertRedirectPaymentResponse AssertRedirectPayment(AssertRedirectPaymentRequest request)
    {
        if (_client != null) return _client.Send<AssertRedirectPaymentResponse, AssertRedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRedirectPayment, request);
        return null;
    }

    [Obsolete("This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public Task<AssertRedirectPaymentResponse> AssertRedirectPaymentAsync(AssertRedirectPaymentRequest request)
    {
        if (_client != null) return _client.SendAsync<AssertRedirectPaymentResponse, AssertRedirectPaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAssertRedirectPayment, request);
        return null;
    }
    #endregion

    #region Inquire 
    public InquireResponse Inquire(InquireRequest request)
    {
        if (_client != null) return _client.Send<InquireResponse, InquireRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInquire, request);
        return null;
    }

    public Task<InquireResponse> InquireAsync(InquireRequest request)
    {
        if (_client != null) return _client.SendAsync<InquireResponse, InquireRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionInquire, request);
        return null;
    }
    #endregion

    #region AlternativePayment 
    public AlternativePaymentResponse AlternativePayment(AlternativePaymentRequest request)
    {
        if (_client != null) return _client.Send<AlternativePaymentResponse, AlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAlternativePayment, request);
        return null;
    }

    public Task<AlternativePaymentResponse> AlternativePaymentAsync(AlternativePaymentRequest request)
    {
        if (_client != null) return _client.SendAsync<AlternativePaymentResponse, AlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionAlternativePayment, request);
        return null;
    }
    #endregion

    #region QueryAlternativePayment 
    public QueryAlternativePaymentResponse QueryAlternativePayment(QueryAlternativePaymentRequest request)
    {
        if (_client != null) return _client.Send<QueryAlternativePaymentResponse, QueryAlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionQueryAlternativePayment, request);
        return null;
    }

    public Task<QueryAlternativePaymentResponse> QueryAlternativePaymentAsync(QueryAlternativePaymentRequest request)
    {
        if (_client != null) return _client.SendAsync<QueryAlternativePaymentResponse, QueryAlternativePaymentRequest>(SaferPayEndpoints.TransactionEndpoint + SaferPayMethods.TransactionQueryAlternativePayment, request);
        return null;
    }
    #endregion

}
