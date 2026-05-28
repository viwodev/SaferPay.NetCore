using SaferPay.Channels;
using SaferPay.Models.Transaction;

namespace SaferPay.Tests.Unit;

/// <summary>
/// Verifies that every <see cref="Transaction"/> method routes to the
/// expected SaferPay endpoint+path. Catches regressions where a method
/// is accidentally wired to the wrong constant in SaferPayMethods.
/// </summary>
public class TransactionRoutingTests
{
    private const string Base = "Payment/v1/Transaction/";

    private static (Transaction Channel, RecordingSaferPayClient Client) NewChannel()
    {
        var fake = new RecordingSaferPayClient();
        return (new Transaction(fake), fake);
    }

    [Fact]
    public async Task InitializeAsync_RoutesTo_Initialize()
    {
        var (c, f) = NewChannel();
        await c.InitializeAsync(new InitializeRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Initialize");
    }

    [Fact]
    public void Initialize_RoutesTo_Initialize()
    {
        var (c, f) = NewChannel();
        c.Initialize(new InitializeRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Initialize");
    }

    [Fact]
    public async Task AuthorizeAsync_RoutesTo_Authorize()
    {
        var (c, f) = NewChannel();
        await c.AuthorizeAsync(new AuthorizeRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Authorize");
    }

    [Fact]
    public async Task AuthorizeDirectAsync_RoutesTo_AuthorizeDirect()
    {
        var (c, f) = NewChannel();
        await c.AuthorizeDirectAsync(new AuthorizeDirectRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "AuthorizeDirect");
    }

    [Fact]
    public async Task AuthorizeReferencedAsync_RoutesTo_AuthorizeReferenced()
    {
        var (c, f) = NewChannel();
        await c.AuthorizeReferencedAsync(new AuthorizeReferencedRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "AuthorizeReferenced");
    }

    [Fact]
    public async Task CaptureAsync_RoutesTo_Capture()
    {
        var (c, f) = NewChannel();
        await c.CaptureAsync(new CaptureRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Capture");
    }

    [Fact]
    public async Task MultipartCaptureAsync_RoutesTo_MultipartCapture()
    {
        var (c, f) = NewChannel();
        await c.MultipartCaptureAsync(new MultipartCaptureRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "MultipartCapture");
    }

    [Fact]
    public async Task AssertCaptureAsync_RoutesTo_AssertCapture()
    {
        var (c, f) = NewChannel();
        await c.AssertCaptureAsync(new AssertCaptureRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "AssertCapture");
    }

    [Fact]
    public async Task MultipartFinalizeAsync_RoutesTo_MultipartFinalize()
    {
        var (c, f) = NewChannel();
        await c.MultipartFinalizeAsync(new MultipartFinalizeRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "MultipartFinalize");
    }

    [Fact]
    public async Task RefundAsync_RoutesTo_Refund()
    {
        var (c, f) = NewChannel();
        await c.RefundAsync(new RefundRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Refund");
    }

    [Fact]
    public async Task AssertRefundAsync_RoutesTo_AssertRefund()
    {
        var (c, f) = NewChannel();
        await c.AssertRefundAsync(new AssertRefundRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "AssertRefund");
    }

    [Fact]
    public async Task RefundDirectAsync_RoutesTo_RefundDirect()
    {
        var (c, f) = NewChannel();
        await c.RefundDirectAsync(new RefundDirectRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "RefundDirect");
    }

    [Fact]
    public async Task CancelAsync_RoutesTo_Cancel()
    {
        var (c, f) = NewChannel();
        await c.CancelAsync(new CancelRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Cancel");
    }

    [Fact]
    public async Task InquireAsync_RoutesTo_Inquire()
    {
        var (c, f) = NewChannel();
        await c.InquireAsync(new InquireRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Inquire");
    }

    [Fact]
    public async Task DccInquiryAsync_RoutesTo_DccInquiry()
    {
        var (c, f) = NewChannel();
        await c.DccInquiryAsync(new DccInquiryRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "DccInquiry");
    }

    [Fact]
    public async Task AlternativePaymentAsync_RoutesTo_AlternativePayment()
    {
        var (c, f) = NewChannel();
        await c.AlternativePaymentAsync(new AlternativePaymentRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "AlternativePayment");
    }

    [Fact]
    public async Task QueryAlternativePaymentAsync_RoutesTo_QueryAlternativePayment()
    {
        var (c, f) = NewChannel();
        await c.QueryAlternativePaymentAsync(new QueryAlternativePaymentRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "QueryAlternativePayment");
    }

    // RedirectPayment / AssertRedirectPayment are [Obsolete]. Still routed,
    // still worth pinning so a future cleanup of the constants doesn't
    // silently break apps that depend on them.
#pragma warning disable CS0618
    [Fact]
    public async Task RedirectPaymentAsync_RoutesTo_RedirectPayment()
    {
        var (c, f) = NewChannel();
        await c.RedirectPaymentAsync(new RedirectPaymentRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "RedirectPayment");
    }

    [Fact]
    public async Task AssertRedirectPaymentAsync_RoutesTo_AssertRedirectPayment()
    {
        var (c, f) = NewChannel();
        await c.AssertRedirectPaymentAsync(new AssertRedirectPaymentRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "AssertRedirectPayment");
    }
#pragma warning restore CS0618
}
