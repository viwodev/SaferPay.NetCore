namespace SaferPay.Tests.Integration;

/// <summary>
/// Exercises the REST pipeline in <see cref="SaferPayClient"/>
/// (Get / Post / Delete + HandleErrorResponse + ProcessFailure) against the
/// real sandbox. The whole branch is otherwise untested — channel-style
/// SOAP-like POSTs hit a different code path.
/// </summary>
[Trait("Category", "Integration")]
public class ManagementApiSandboxTests
{
    [SandboxFact]
    public async Task TerminalGetTerminal_ReturnsTerminalInfo()
    {
        // Exercises Get<TResponse>(path) on a known-good endpoint:
        //   - URL composition (BaseUri + rest/customers/{cid}/terminals/{tid})
        //   - Basic auth
        //   - Saferpay-ApiVersion + Saferpay-RequestId headers
        //   - 200 OK branch + JSON deserialization
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var response = await client.ManagementApi.TerminalGetTerminalAsync();

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeTrue($"sandbox returned: {response.Error?.ErrorMessage}");
        response.TerminalId.Should().Be(settings.TerminalId);
    }

    [SandboxFact]
    public async Task LicensingCustomerLicense_ReturnsLicenseInfo()
    {
        // Second Get<TResponse>(path), different shape — guards against
        // accidental coupling between deserialization and a single response type.
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = true;

        using var client = new SaferPayClient(settings);

        var response = await client.ManagementApi.LicensingCustomerLicenseAsync();

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeTrue($"sandbox returned: {response.Error?.ErrorMessage}");
    }

    [SandboxFact]
    public async Task SecurePayGate_SingleUsePaymentLink_OnUnknownOffer_ReturnsErrorEnvelope()
    {
        // Exercises the 404 branch in Get<TResponse>:
        //   - "Requested resource not found (404)." synthetic ErrorResponse
        //   - ThrowExceptionOnFail=false → returned in envelope, not thrown
        var settings = SandboxEnvironment.BuildSettings();
        settings.ThrowExceptionOnFail = false;

        using var client = new SaferPayClient(settings);

        var response = await client.ManagementApi.SecurePayGateSingleUsePaymentLinkAsync(
            Guid.NewGuid().ToString());

        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
        response.Error!.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }

    // NOTE: a Delete<TResponse> test would naturally go here, but the only
    // ManagementApi method that wires DeleteAsync — SaferpayFieldsAccessToken
    // DeleteAccessTokenAsync — declares Task<RestResponseBase>, and
    // RestResponseBase is abstract. The SDK's error path runs
    // Activator.CreateInstance<TResponse>() on failure, which crashes with
    // MissingMethodException on an abstract type. Method is therefore
    // unsendable as-is; covering it requires fixing the channel signature
    // first (e.g. introducing a concrete AccessTokenDeleteResponse).
}
