using SaferPay.Channels;
using SaferPay.Models.PaymentPage;

namespace SaferPay.Tests.Unit;

public class PaymentPageRoutingTests
{
    private const string Base = "Payment/v1/PaymentPage/";

    private static (PaymentPage Channel, RecordingSaferPayClient Client) NewChannel()
    {
        var fake = new RecordingSaferPayClient();
        return (new PaymentPage(fake), fake);
    }

    [Fact]
    public async Task InitializeAsync_RoutesTo_Initialize()
    {
        var (c, f) = NewChannel();
        await c.InitializeAsync(new InitializePaymentPageRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Initialize");
    }

    [Fact]
    public async Task AssertAsync_WithRequest_RoutesTo_Assert()
    {
        var (c, f) = NewChannel();
        await c.AssertAsync(new AssertRequest("tok"));
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Assert");
    }

    [Fact]
    public async Task AssertAsync_WithToken_RoutesTo_Assert()
    {
        // String overload constructs the request internally — verify it still
        // routes to the same endpoint.
        var (c, f) = NewChannel();
        await c.AssertAsync("tok");
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Assert");
    }

    [Fact]
    public void Assert_WithToken_RoutesTo_Assert()
    {
        var (c, f) = NewChannel();
        c.Assert("tok");
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Assert");
    }
}
