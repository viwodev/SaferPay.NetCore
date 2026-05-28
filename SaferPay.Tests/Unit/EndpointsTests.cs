using SaferPay.Config;

namespace SaferPay.Tests.Unit;

public class EndpointsTests
{
    [Fact]
    public void ApiVersion_IsCurrent()
    {
        SaferPayApiConstants.Version.Should().Be("1.52");
    }

    [Theory]
    [InlineData("Payment/v1/Transaction/", "TransactionEndpoint")]
    [InlineData("Payment/v1/PaymentPage/", "PaymentPageEndpoint")]
    [InlineData("Payment/v1/Alias/", "AliasEndpoint")]
    [InlineData("Payment/v1/Batch/", "BatchEndpoint")]
    [InlineData("Payment/v1/OmniChannel/", "OmniChannelEndpoint")]
    public void Endpoints_AreStable(string expected, string field)
    {
        var f = typeof(SaferPayEndpoints).GetField(field)!;
        f.GetValue(null).Should().Be(expected);
    }

    [Fact]
    public void Methods_HaveExpectedPaths()
    {
        SaferPayMethods.TransactionInitialize.Should().Be("Initialize");
        SaferPayMethods.TransactionAuthorize.Should().Be("Authorize");
        SaferPayMethods.TransactionCapture.Should().Be("Capture");
        SaferPayMethods.TransactionRefund.Should().Be("Refund");
        SaferPayMethods.PaymentPageInitialize.Should().Be("Initialize");
        SaferPayMethods.PaymentPageAssert.Should().Be("Assert");
    }
}
