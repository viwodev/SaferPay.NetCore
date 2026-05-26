using SaferPay.Models.Transaction;

namespace SaferPay.Tests.Unit;

public class RefundRequestTests
{
    [Fact]
    public void Ctor_DecimalAmount_BuildsRefundAndCaptureReference()
    {
        var req = new RefundRequest("txn-123", 5.50m, "CHF");

        req.CaptureReference.Should().NotBeNull();
        req.CaptureReference.TransactionId.Should().Be("txn-123");
        req.Refund.Should().NotBeNull();
        req.Refund.Amount.Value.Should().Be("550");
        req.Refund.Amount.CurrencyCode.Should().Be("CHF");
    }

    [Fact]
    public void Ctor_StringAmount_StoresValueVerbatim()
    {
        var req = new RefundRequest("txn-9", "12345", "EUR");
        req.Refund.Amount.Value.Should().Be("12345");
        req.Refund.Amount.CurrencyCode.Should().Be("EUR");
        req.CaptureReference.TransactionId.Should().Be("txn-9");
    }
}
