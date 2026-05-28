using SaferPay.Channels;
using SaferPay.Models.Batch;
using SaferPay.Models.OmniChannel;

namespace SaferPay.Tests.Unit;

public class BatchAndOmniChannelRoutingTests
{
    [Fact]
    public async Task Batch_CloseAsync_RoutesTo_BatchClose()
    {
        var fake = new RecordingSaferPayClient();
        var channel = new Batch(fake);
        await channel.CloseAsync(new BatchRequest());
        fake.Calls.Should().ContainSingle().Which.Path.Should().Be("Payment/v1/Batch/Close");
    }

    [Fact]
    public async Task OmniChannel_AcquireTransactionAsync_RoutesTo_AcquireTransaction()
    {
        var fake = new RecordingSaferPayClient();
        var channel = new OmniChannel(fake);
        await channel.AcquireTransactionAsync(new AcquireTransactionRequest());
        fake.Calls.Should().ContainSingle().Which.Path.Should().Be("Payment/v1/OmniChannel/AcquireTransaction");
    }

    [Fact]
    public async Task OmniChannel_InsertAliasAsync_RoutesTo_InsertAlias()
    {
        var fake = new RecordingSaferPayClient();
        var channel = new OmniChannel(fake);
        await channel.InsertAliasAsync(new InsertAliasRequest());
        fake.Calls.Should().ContainSingle().Which.Path.Should().Be("Payment/v1/OmniChannel/InsertAlias");
    }
}
