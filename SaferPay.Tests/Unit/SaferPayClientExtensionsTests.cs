using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Management;
using SaferPay.Models.PaymentPage;
using SaferPay.Models.Transaction;

namespace SaferPay.Tests.Unit;

public class SaferPayClientExtensionsTests
{
    [Fact]
    public void InitializeTransaction_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new InitializeRequest();

        _ = fake.InitializeTransaction(req);

        fake.Transaction.LastInitialize.Should().BeSameAs(req);
    }

    [Fact]
    public async Task InitializeTransactionAsync_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new InitializeRequest();

        _ = await fake.InitializeTransactionAsync(req);

        fake.Transaction.LastInitialize.Should().BeSameAs(req);
    }

    [Fact]
    public void Authorize_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new AuthorizeRequest();

        _ = fake.Authorize(req);

        fake.Transaction.LastAuthorize.Should().BeSameAs(req);
    }

    [Fact]
    public async Task AuthorizeAsync_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new AuthorizeRequest();

        _ = await fake.AuthorizeAsync(req);

        fake.Transaction.LastAuthorize.Should().BeSameAs(req);
    }

    [Fact]
    public void Capture_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new CaptureRequest("txn");

        _ = fake.Capture(req);

        fake.Transaction.LastCapture.Should().BeSameAs(req);
    }

    [Fact]
    public async Task CaptureAsync_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new CaptureRequest("txn");

        _ = await fake.CaptureAsync(req);

        fake.Transaction.LastCapture.Should().BeSameAs(req);
    }

    [Fact]
    public void Cancel_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new CancelRequest();

        _ = fake.Cancel(req);

        fake.Transaction.LastCancel.Should().BeSameAs(req);
    }

    [Fact]
    public async Task CancelAsync_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new CancelRequest();

        _ = await fake.CancelAsync(req);

        fake.Transaction.LastCancel.Should().BeSameAs(req);
    }

    [Fact]
    public void Refund_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new RefundRequest("txn", 1m, "CHF");

        _ = fake.Refund(req);

        fake.Transaction.LastRefund.Should().BeSameAs(req);
    }

    [Fact]
    public async Task RefundAsync_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new RefundRequest("txn", 1m, "CHF");

        _ = await fake.RefundAsync(req);

        fake.Transaction.LastRefund.Should().BeSameAs(req);
    }

    [Fact]
    public void Inquiry_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new InquireRequest();

        _ = fake.Inquiry(req);

        fake.Transaction.LastInquire.Should().BeSameAs(req);
    }

    [Fact]
    public async Task InquiryAsync_DelegatesToTransactionChannel()
    {
        var fake = new FakeClient();
        var req = new InquireRequest();

        _ = await fake.InquiryAsync(req);

        fake.Transaction.LastInquire.Should().BeSameAs(req);
    }

    [Fact]
    public void InitializePaymentPage_DelegatesToPaymentPageChannel()
    {
        var fake = new FakeClient();
        var req = new InitializePaymentPageRequest();

        _ = fake.InitializePaymentPage(req);

        fake.PaymentPage.LastInitialize.Should().BeSameAs(req);
    }

    [Fact]
    public async Task InitializePaymentPageAsync_DelegatesToPaymentPageChannel()
    {
        var fake = new FakeClient();
        var req = new InitializePaymentPageRequest();

        _ = await fake.InitializePaymentPageAsync(req);

        fake.PaymentPage.LastInitialize.Should().BeSameAs(req);
    }

    [Fact]
    public void AssertPaymentPage_DelegatesToPaymentPageChannel()
    {
        var fake = new FakeClient();
        var req = new AssertRequest("tok");

        _ = fake.AssertPaymentPage(req);

        fake.PaymentPage.LastAssert.Should().BeSameAs(req);
    }

    [Fact]
    public async Task AssertPaymentPageAsync_DelegatesToPaymentPageChannel()
    {
        var fake = new FakeClient();
        var req = new AssertRequest("tok");

        _ = await fake.AssertPaymentPageAsync(req);

        fake.PaymentPage.LastAssert.Should().BeSameAs(req);
    }

    private sealed class FakeClient : ISaferPayClient
    {
        public FakeTransaction Transaction { get; } = new();
        public FakePaymentPage PaymentPage { get; } = new();

        ITransaction ISaferPayClient.Transaction => Transaction;
        IPaymentPage ISaferPayClient.PaymentPage => PaymentPage;
        ISecureCardData ISaferPayClient.SecureCardData => throw new NotImplementedException();
        IBatch ISaferPayClient.Batch => throw new NotImplementedException();
        IOmniChannel ISaferPayClient.OmniChannel => throw new NotImplementedException();
        IManagementApi ISaferPayClient.ManagementApi => throw new NotImplementedException();

        public string CustomerId => "c";
        public string TerminalId => "t";

        public TResponse Send<TResponse, TRequest>(string path, TRequest request)
            where TRequest : RequestBase
            where TResponse : ResponseBase
            => throw new NotImplementedException();

        public Task<TResponse> SendAsync<TResponse, TRequest>(string path, TRequest request)
            where TRequest : RequestBase
            where TResponse : ResponseBase
            => throw new NotImplementedException();

        public TResponse Get<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
        public Task<TResponse> GetAsync<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
        public TResponse Get<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
        public Task<TResponse> GetAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
        public TResponse Post<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
        public Task<TResponse> PostAsync<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
        public TResponse Post<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
        public Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
        public TResponse Delete<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
        public Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();

        public void Dispose() { }
    }

    private sealed class FakeTransaction : ITransaction
    {
        public InitializeRequest? LastInitialize;
        public AuthorizeRequest? LastAuthorize;
        public CaptureRequest? LastCapture;
        public CancelRequest? LastCancel;
        public RefundRequest? LastRefund;
        public InquireRequest? LastInquire;

        public InitializeResponse Initialize(InitializeRequest request) { LastInitialize = request; return new(); }
        public Task<InitializeResponse> InitializeAsync(InitializeRequest request) { LastInitialize = request; return Task.FromResult(new InitializeResponse()); }

        public AuthorizeResponse Authorize(AuthorizeRequest request) { LastAuthorize = request; return new(); }
        public Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request) { LastAuthorize = request; return Task.FromResult(new AuthorizeResponse()); }

        public CaptureResponse Capture(CaptureRequest request) { LastCapture = request; return new(); }
        public Task<CaptureResponse> CaptureAsync(CaptureRequest request) { LastCapture = request; return Task.FromResult(new CaptureResponse()); }

        public CancelResponse Cancel(CancelRequest request) { LastCancel = request; return new(); }
        public Task<CancelResponse> CancelAsync(CancelRequest request) { LastCancel = request; return Task.FromResult(new CancelResponse()); }

        public RefundResponse Refund(RefundRequest request) { LastRefund = request; return new(); }
        public Task<RefundResponse> RefundAsync(RefundRequest request) { LastRefund = request; return Task.FromResult(new RefundResponse()); }

        public InquireResponse Inquire(InquireRequest request) { LastInquire = request; return new(); }
        public Task<InquireResponse> InquireAsync(InquireRequest request) { LastInquire = request; return Task.FromResult(new InquireResponse()); }

        // Unused members
        public AuthorizeDirectResponse AuthorizeDirect(AuthorizeDirectRequest request) => new();
        public Task<AuthorizeDirectResponse> AuthorizeDirectAsync(AuthorizeDirectRequest request) => Task.FromResult(new AuthorizeDirectResponse());
        public AuthorizeReferencedResponse AuthorizeReferenced(AuthorizeReferencedRequest request) => new();
        public Task<AuthorizeReferencedResponse> AuthorizeReferencedAsync(AuthorizeReferencedRequest request) => Task.FromResult(new AuthorizeReferencedResponse());
        public MultipartCaptureResponse MultipartCapture(MultipartCaptureRequest request) => new();
        public Task<MultipartCaptureResponse> MultipartCaptureAsync(MultipartCaptureRequest request) => Task.FromResult(new MultipartCaptureResponse());
        public AssertCaptureResponse AssertCapture(AssertCaptureRequest request) => new();
        public Task<AssertCaptureResponse> AssertCaptureAsync(AssertCaptureRequest request) => Task.FromResult(new AssertCaptureResponse());
        public MultipartFinalizeResponse MultipartFinalize(MultipartFinalizeRequest request) => new();
        public Task<MultipartFinalizeResponse> MultipartFinalizeAsync(MultipartFinalizeRequest request) => Task.FromResult(new MultipartFinalizeResponse());
        public AssertRefundResponse AssertRefund(AssertRefundRequest request) => new();
        public Task<AssertRefundResponse> AssertRefundAsync(AssertRefundRequest request) => Task.FromResult(new AssertRefundResponse());
        public RefundDirectResponse RefundDirect(RefundDirectRequest request) => new();
        public Task<RefundDirectResponse> RefundDirectAsync(RefundDirectRequest request) => Task.FromResult(new RefundDirectResponse());
        public RedirectPaymentResponse RedirectPayment(RedirectPaymentRequest request) => new();
        public Task<RedirectPaymentResponse> RedirectPaymentAsync(RedirectPaymentRequest request) => Task.FromResult(new RedirectPaymentResponse());
        public AssertRedirectPaymentResponse AssertRedirectPayment(AssertRedirectPaymentRequest request) => new();
        public Task<AssertRedirectPaymentResponse> AssertRedirectPaymentAsync(AssertRedirectPaymentRequest request) => Task.FromResult(new AssertRedirectPaymentResponse());
        public AlternativePaymentResponse AlternativePayment(AlternativePaymentRequest request) => new();
        public Task<AlternativePaymentResponse> AlternativePaymentAsync(AlternativePaymentRequest request) => Task.FromResult(new AlternativePaymentResponse());
        public QueryAlternativePaymentResponse QueryAlternativePayment(QueryAlternativePaymentRequest request) => new();
        public Task<QueryAlternativePaymentResponse> QueryAlternativePaymentAsync(QueryAlternativePaymentRequest request) => Task.FromResult(new QueryAlternativePaymentResponse());
        public DccInquiryResponse DccInquire(DccInquiryRequest request) => new();
        public Task<DccInquiryResponse> DccInquiryAsync(DccInquiryRequest request) => Task.FromResult(new DccInquiryResponse());
    }

    private sealed class FakePaymentPage : IPaymentPage
    {
        public InitializePaymentPageRequest? LastInitialize;
        public AssertRequest? LastAssert;

        public InitializePaymentPageResponse Initialize(InitializePaymentPageRequest request) { LastInitialize = request; return new(); }
        public Task<InitializePaymentPageResponse> InitializeAsync(InitializePaymentPageRequest request) { LastInitialize = request; return Task.FromResult(new InitializePaymentPageResponse()); }
        public AssertResponse Assert(AssertRequest request) { LastAssert = request; return new(); }
        public AssertResponse Assert(string token) { LastAssert = new AssertRequest(token); return new(); }
        public Task<AssertResponse> AssertAsync(AssertRequest request) { LastAssert = request; return Task.FromResult(new AssertResponse()); }
        public Task<AssertResponse> AssertAsync(string token) { LastAssert = new AssertRequest(token); return Task.FromResult(new AssertResponse()); }
    }
}
