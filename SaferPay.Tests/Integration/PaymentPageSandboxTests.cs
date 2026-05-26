using SaferPay.Models.PaymentPage;

namespace SaferPay.Tests.Integration;

[Trait("Category", "Integration")]
public class PaymentPageSandboxTests
{
    [SandboxFact]
    public async Task Initialize_ReturnsRedirectUrlAndToken()
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

        var response = await client.PaymentPage.InitializeAsync(request);

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeTrue($"expected success but got {response.Error?.ErrorMessage}");
        response.Token.Should().NotBeNullOrWhiteSpace();
        response.RedirectUrl.Should().NotBeNullOrWhiteSpace();
        response.RedirectUrl.Should().StartWith("https://");
    }

    [SandboxFact]
    public async Task Assert_OnFreshToken_ReturnsErrorResponse_NotException()
    {
        // We cannot run a payer through 3DS in CI, but Assert on a still-pending token
        // must return a well-formed error envelope rather than crashing the client.
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var orderId = $"it-pp-{Guid.NewGuid():n}";
        var init = await client.PaymentPage.InitializeAsync(new InitializePaymentPageRequest(
            settings.TerminalId, 1.00m, "CHF", orderId, "https://example.com/return"));

        init.IsSuccess.Should().BeTrue();

        var assert = await client.PaymentPage.AssertAsync(new AssertRequest(init.Token));

        assert.Should().NotBeNull();
        // We expect either success (unlikely on a fresh, not-redirected token) or a
        // populated Error payload — but never null.
        (assert.IsSuccess || assert.Error is not null).Should().BeTrue();
    }
}
