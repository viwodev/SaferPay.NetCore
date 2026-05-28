using SaferPay.Channels;
using SaferPay.Models.SecureData;

namespace SaferPay.Tests.Unit;

public class SecureCardDataRoutingTests
{
    private const string Base = "Payment/v1/Alias/";

    private static (SecureCardData Channel, RecordingSaferPayClient Client) NewChannel()
    {
        var fake = new RecordingSaferPayClient();
        return (new SecureCardData(fake), fake);
    }

    [Fact]
    public async Task AliasInsertAsync_RoutesTo_Insert()
    {
        var (c, f) = NewChannel();
        await c.AliasInsertAsync(new AliasInsertRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Insert");
    }

    [Fact]
    public async Task AssertInsertAsync_RoutesTo_AssertInsert()
    {
        var (c, f) = NewChannel();
        await c.AssertInsertAsync(new AssertInsertRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "AssertInsert");
    }

    [Fact]
    public async Task InsertDirectAsync_RoutesTo_InsertDirect()
    {
        var (c, f) = NewChannel();
        await c.InsertDirectAsync(new InsertDirectRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "InsertDirect");
    }

    [Fact]
    public async Task AliasUpdateAsync_RoutesTo_Update()
    {
        var (c, f) = NewChannel();
        await c.AliasUpdateAsync(new AliasUpdateRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Update");
    }

    [Fact]
    public async Task AliasDeleteAsync_RoutesTo_Delete()
    {
        var (c, f) = NewChannel();
        await c.AliasDeleteAsync(new AliasDeleteRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Delete");
    }

    [Fact]
    public async Task AliasInquireAsync_RoutesTo_Inquire()
    {
        var (c, f) = NewChannel();
        await c.AliasInquireAsync(new AliasInquireRequest());
        f.Calls.Should().ContainSingle().Which.Path.Should().Be(Base + "Inquire");
    }
}
