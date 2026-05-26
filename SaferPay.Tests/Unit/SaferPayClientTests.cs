using SaferPay.Interfaces;
using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class SaferPayClientTests
{
    private static SaferPayClient NewClient() =>
        new("cust-id", "term-id", "user", "pwd", sandBox: true);

    [Fact]
    public void Constructor_ExposesCustomerAndTerminal()
    {
        var c = NewClient();
        c.CustomerId.Should().Be("cust-id");
        c.TerminalId.Should().Be("term-id");
    }

    [Fact]
    public void Channels_AreNotNull()
    {
        var c = NewClient();
        c.Transaction.Should().NotBeNull();
        c.PaymentPage.Should().NotBeNull();
        c.SecureCardData.Should().NotBeNull();
        c.Batch.Should().NotBeNull();
        c.OmniChannel.Should().NotBeNull();
        c.ManagementApi.Should().NotBeNull();
    }

    [Fact]
    public void SendAsync_Throws_OnNullRequest()
    {
        var c = NewClient();
        Func<Task> act = () => c.SendAsync<DummyResponse, DummyRequest>("any/path", null!);
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public void Send_Throws_OnNullRequest()
    {
        var c = NewClient();
        Action act = () => c.Send<DummyResponse, DummyRequest>("any/path", null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Dispose_DoesNotThrow()
    {
        using var c = NewClient();
        Action act = () => c.Dispose();
        act.Should().NotThrow();
    }

    private sealed class DummyRequest : RequestBase { }
    private sealed class DummyResponse : ResponseBase { }
}
