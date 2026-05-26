using SaferPay.Models.Transaction;

namespace SaferPay.Tests.Integration;

[Trait("Category", "Integration")]
public class TransactionFlowSandboxTests
{
    /// <summary>
    /// Initialize → Authorize on a fresh token. Authorize without a real payer flow
    /// will be rejected by the sandbox, but the rejection should come back as a
    /// structured ErrorResponse rather than an unhandled exception.
    /// </summary>
    [SandboxFact]
    public async Task Initialize_Then_Authorize_RoundTrips_ErrorEnvelope()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var orderId = $"it-tx-{Guid.NewGuid():n}";
        var init = await client.Transaction.InitializeAsync(new InitializeRequest(
            settings.TerminalId, 1.00m, "CHF", orderId, "https://example.com/return"));

        init.Should().NotBeNull();
        init.IsSuccess.Should().BeTrue($"expected init success but got {init.Error?.ErrorMessage}");
        init.Token.Should().NotBeNullOrWhiteSpace();

        var auth = await client.Transaction.AuthorizeAsync(new AuthorizeRequest(init.Token));

        auth.Should().NotBeNull();
        // Authorize without a card / 3DS flow is expected to fail; we only verify
        // the error envelope is intact — the client must surface API errors as data,
        // not as crashes when ThrowExceptionOnFail is false.
        (auth.IsSuccess || auth.Error is not null).Should().BeTrue();
    }

    /// <summary>
    /// Capture/Refund need a real authorized transaction id. We cannot obtain one
    /// without driving the payer flow, so this test just confirms that calling
    /// Capture against a bogus reference yields an ErrorResponse rather than a crash.
    /// The full happy-path Capture/Refund flow is documented in
    /// SaferPay.Test (the interactive console playground).
    /// </summary>
    [SandboxFact]
    public async Task Capture_OnUnknownTransaction_ReturnsErrorEnvelope()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var result = await client.Transaction.CaptureAsync(
            new CaptureRequest("does-not-exist-" + Guid.NewGuid().ToString("n")));

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();
    }
}
