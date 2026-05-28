using SaferPay.Exceptions;
using SaferPay.Models.Core;
using SaferPay.Models.PaymentPage;

namespace SaferPay.Tests.Integration;

[Trait("Category", "Integration")]
public class PaymentPageSandboxTests
{
    [SandboxFact]
    public async Task Initialize_SuccessPath_DeserializesTokenAndRedirectUrl()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var orderId = $"it-pp-{Guid.NewGuid():n}";
        var request = new InitializePaymentPageRequest(
            terminalId: settings.TerminalId,
            amount: 1.00m,
            currencyCode: "CHF",
            orderId: orderId,
            returnURL: "https://example.com/return");
        request.Payment.Description = "Integration test";

        var response = await client.PaymentPage.InitializeAsync(request);

        // Validates the entire success pipeline:
        //   - HTTP Basic auth, RequestId header, JSON body serialization
        //   - 200 OK branch in SaferPayClient.SendAsync
        //   - ResponseStatus.SUCCESS assignment
        //   - Newtonsoft.Json deserialization of nested response shape
        response.Should().NotBeNull();
        response.IsSuccess.Should().BeTrue($"sandbox returned error: {response.Error?.ErrorMessage}");
        response.Token.Should().NotBeNullOrWhiteSpace();
        response.RedirectUrl.Should().StartWith("https://test.saferpay.com/");
        response.Expiration.Should().BeAfter(DateTimeOffset.UtcNow);
        response.ResponseHeader.Should().NotBeNull();
        response.ResponseHeader.RequestId.Should().NotBeNullOrWhiteSpace();
    }

    [SandboxFact]
    public async Task Initialize_BadAmount_WithoutThrow_ReturnsStructuredError()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        // Negative amount → sandbox rejects with VALIDATION_FAILED.
        var request = new InitializePaymentPageRequest(
            terminalId: settings.TerminalId,
            amount: -1m,
            currencyCode: "CHF",
            orderId: $"it-pp-bad-{Guid.NewGuid():n}",
            returnURL: "https://example.com/return");

        var response = await client.PaymentPage.InitializeAsync(request);

        // Validates the error pipeline with ThrowExceptionOnFail=false:
        //   - non-200 branch in SaferPayClient.SendAsync
        //   - ErrorResponse deserialization
        //   - ResponseStatus.ERROR assignment, Error property populated
        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
        response.Error!.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }

    [SandboxFact]
    public async Task Initialize_BadAmount_WithThrow_ThrowsTypedException()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var request = new InitializePaymentPageRequest(
            terminalId: settings.TerminalId,
            amount: -1m,
            currencyCode: "CHF",
            orderId: $"it-pp-bad-{Guid.NewGuid():n}",
            returnURL: "https://example.com/return");

        // Validates that the ThrowExceptionOnFail=true branch surfaces a typed
        // SaferPayException carrying both HTTP status and the parsed ErrorResponse.
        var act = () => client.PaymentPage.InitializeAsync(request);

        var ex = (await act.Should().ThrowAsync<SaferPayException>()).Which;
        ex.HttpStatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        ex.ErrorResponse.Should().NotBeNull();
        ex.ErrorResponse.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }

    [SandboxFact]
    public async Task Initialize_WithBadCredentials_ReturnsAuthError()
    {
        // Validates HTTP Basic auth + 401 handling.
        var settings = new SaferPaySettings(
            customerId: SandboxEnvironment.BuildSettings().CustomerId,
            terminalId: SandboxEnvironment.BuildSettings().TerminalId,
            userName: "API_INVALID",
            passWord: "INVALID",
            sandBox: true)
        {
            ThrowExceptionOnFail = false,
        };

        using var client = new SaferPayClient(settings);

        var request = new InitializePaymentPageRequest(
            terminalId: settings.TerminalId,
            amount: 1m,
            currencyCode: "CHF",
            orderId: $"it-pp-auth-{Guid.NewGuid():n}",
            returnURL: "https://example.com/return");

        var response = await client.PaymentPage.InitializeAsync(request);

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
    }

    [SandboxFact]
    public async Task Assert_OnFreshUnredirectedToken_ReturnsErrorEnvelope()
    {
        // The payer hasn't been through the redirect flow, so Assert is expected
        // to error out. We only verify the envelope is well-formed, not the verdict.
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var initRequest = new InitializePaymentPageRequest(
            settings.TerminalId, 1m, "CHF", $"it-pp-{Guid.NewGuid():n}", "https://example.com/return");
        initRequest.Payment.Description = "Integration test";

        var init = await client.PaymentPage.InitializeAsync(initRequest);
        init.IsSuccess.Should().BeTrue();

        var assert = await client.PaymentPage.AssertAsync(new AssertRequest(init.Token));

        assert.Should().NotBeNull();
        (assert.IsSuccess || assert.Error is not null).Should().BeTrue();
    }
}
