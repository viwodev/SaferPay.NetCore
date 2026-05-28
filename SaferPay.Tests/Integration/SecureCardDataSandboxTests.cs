using SaferPay.Enums;
using SaferPay.Exceptions;
using SaferPay.Models.Core;
using SaferPay.Models.SecureData;

namespace SaferPay.Tests.Integration;

[Trait("Category", "Integration")]
public class SecureCardDataSandboxTests
{
    [SandboxFact]
    public async Task AliasInsert_SuccessPath_ReturnsTokenAndRedirect()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var request = new AliasInsertRequest
        {
            // RANDOM_UNIQUE avoids having to invent a unique alias id ourselves.
            // Lifetime left null on purpose: relies on the Saferpay default
            // (1096 days) and exercises the nullable-int omission path.
            RegisterAlias = new RegisterAlias { IdGenerator = IdGeneratorTypes.RANDOM_UNIQUE },
            Type = AliasType.CARD,
            ReturnUrl = new ReturnUrl("https://example.com/return"),
        };

        var response = await client.SecureCardData.AliasInsertAsync(request);

        // Validates the alias-insert pipeline end-to-end:
        //   - request serialization (RegisterAlias + ReturnUrl + enum values)
        //   - 200 OK branch in SaferPayClient.SendAsync
        //   - AliasInsertResponse deserialization (Token + Redirect + Expiration)
        response.Should().NotBeNull();
        response.IsSuccess.Should().BeTrue($"sandbox returned: {response.Error?.ErrorMessage}");
        response.Token.Should().NotBeNullOrWhiteSpace();
        response.RedirectRequired.Should().BeTrue();
        response.Redirect.Should().NotBeNull();
        response.Redirect.RedirectUrl.Should().StartWith("https://test.saferpay.com/");
        response.Expiration.Should().BeAfter(DateTimeOffset.UtcNow);
    }

    [SandboxFact]
    public async Task AliasInsert_WithBadCredentials_ReturnsAuthError()
    {
        var baseline = SandboxEnvironment.BuildSettings();
        var settings = new SaferPaySettings(
            customerId: baseline.CustomerId,
            terminalId: baseline.TerminalId,
            userName: "API_INVALID",
            passWord: "INVALID",
            sandBox: true)
        {
            ThrowExceptionOnFail = false,
        };

        using var client = new SaferPayClient(settings);

        var response = await client.SecureCardData.AliasInsertAsync(new AliasInsertRequest
        {
            RegisterAlias = new RegisterAlias { IdGenerator = IdGeneratorTypes.RANDOM_UNIQUE, Lifetime = 1000 },
            Type = AliasType.CARD,
            ReturnUrl = new ReturnUrl("https://example.com/return"),
        });

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
    }

    [SandboxFact]
    public async Task AliasInquire_OnUnknownAliasId_ReturnsErrorEnvelope()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var response = await client.SecureCardData.AliasInquireAsync(new AliasInquireRequest
        {
            AliasId = "does-not-exist-" + Guid.NewGuid().ToString("n"),
        });

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
        response.Error!.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }

    [SandboxFact]
    public async Task AliasInquire_OnUnknownAliasId_WithThrow_ThrowsTypedException()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var act = () => client.SecureCardData.AliasInquireAsync(new AliasInquireRequest
        {
            AliasId = "does-not-exist-" + Guid.NewGuid().ToString("n"),
        });

        var ex = (await act.Should().ThrowAsync<SaferPayException>()).Which;
        ex.ErrorResponse.Should().NotBeNull();
        ((int)ex.HttpStatusCode).Should().BeInRange(400, 599);
    }

    [SandboxFact]
    public async Task AliasDelete_OnUnknownAliasId_ReturnsErrorEnvelope()
    {
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var response = await client.SecureCardData.AliasDeleteAsync(new AliasDeleteRequest
        {
            AliasId = "does-not-exist-" + Guid.NewGuid().ToString("n"),
        });

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
    }
}
