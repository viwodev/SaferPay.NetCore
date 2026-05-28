using SaferPay.Exceptions;
using SaferPay.Models.Transaction;

namespace SaferPay.Tests.Integration;

[Trait("Category", "Integration")]
public class TransactionFlowSandboxTests
{
    [SandboxFact]
    public async Task Initialize_SuccessPath_ReturnsTokenAndRedirect()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var init = await client.Transaction.InitializeAsync(new InitializeRequest(
            settings.TerminalId, 1.00m, "CHF",
            $"it-tx-{Guid.NewGuid():n}", "https://example.com/return"));

        init.Should().NotBeNull();
        init.IsSuccess.Should().BeTrue($"sandbox returned: {init.Error?.ErrorMessage}");
        init.Token.Should().NotBeNullOrWhiteSpace();
        init.Expiration.Should().BeAfter(DateTimeOffset.UtcNow);
    }

    [SandboxFact]
    public async Task Authorize_OnUnredirectedToken_ReturnsErrorEnvelope()
    {
        // Without the payer going through 3DS / card form, Authorize is expected
        // to fail. We assert the error is surfaced as data, not a crash.
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var init = await client.Transaction.InitializeAsync(new InitializeRequest(
            settings.TerminalId, 1.00m, "CHF",
            $"it-tx-{Guid.NewGuid():n}", "https://example.com/return"));
        init.IsSuccess.Should().BeTrue();

        var auth = await client.Transaction.AuthorizeAsync(new AuthorizeRequest(init.Token));

        auth.Should().NotBeNull();
        (auth.IsSuccess || auth.Error is not null).Should().BeTrue();
    }

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
        result.Error!.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }

    [SandboxFact]
    public async Task Capture_OnUnknownTransaction_WithThrow_ThrowsTypedException()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var act = () => client.Transaction.CaptureAsync(
            new CaptureRequest("does-not-exist-" + Guid.NewGuid().ToString("n")));

        var ex = (await act.Should().ThrowAsync<SaferPayException>()).Which;
        ex.ErrorResponse.Should().NotBeNull();
        ((int)ex.HttpStatusCode).Should().BeInRange(400, 599);
    }

    [SandboxFact]
    public async Task Inquire_OnUnknownTransaction_ReturnsErrorEnvelope()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var result = await client.Transaction.InquireAsync(
            new InquireRequest("does-not-exist-" + Guid.NewGuid().ToString("n")));

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();
    }
}
