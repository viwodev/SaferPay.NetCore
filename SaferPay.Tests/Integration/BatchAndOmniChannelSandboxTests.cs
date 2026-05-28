using SaferPay.Models.Batch;
using SaferPay.Models.OmniChannel;

namespace SaferPay.Tests.Integration;

[Trait("Category", "Integration")]
public class BatchAndOmniChannelSandboxTests
{
    [SandboxFact]
    public async Task Batch_Close_OnInvalidTerminal_ReturnsErrorEnvelope()
    {
        // Exercises the Batch channel pipeline end-to-end. We don't close the
        // real sandbox batch (side-effect-y) — instead we send a bogus terminal
        // and assert the SDK surfaces a structured error.
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var response = await client.Batch.CloseAsync(new BatchRequest
        {
            TerminalId = "00000000",
        });

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
        response.Error!.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }

    [SandboxFact]
    public async Task OmniChannel_AcquireTransaction_OnUnknownReference_ReturnsErrorEnvelope()
    {
        // Exercises the OmniChannel pipeline + AcquireTransactionRequest
        // serialization (OrderId + TerminalId + SixTransactionReference).
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var response = await client.OmniChannel.AcquireTransactionAsync(new AcquireTransactionRequest
        {
            TerminalId = settings.TerminalId,
            OrderId = $"it-oc-{Guid.NewGuid():n}",
            SixTransactionReference = "0:000000:000000000000",
        });

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
    }
}
