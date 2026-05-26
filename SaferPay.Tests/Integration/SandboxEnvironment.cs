using SaferPay.Models.Core;

namespace SaferPay.Tests.Integration;

/// <summary>
/// Reads sandbox credentials from environment variables so that integration tests
/// stay opt-in. CI exports these from repo secrets only when running the
/// integration job, so local unit-test runs and PR builds never hit the network.
/// </summary>
internal static class SandboxEnvironment
{
    public const string CustomerIdVar = "SAFERPAY_CUSTOMER_ID";
    public const string TerminalIdVar = "SAFERPAY_TERMINAL_ID";
    public const string UsernameVar = "SAFERPAY_USERNAME";
    public const string PasswordVar = "SAFERPAY_PASSWORD";

    public static bool IsAvailable =>
        !string.IsNullOrWhiteSpace(Get(CustomerIdVar)) &&
        !string.IsNullOrWhiteSpace(Get(TerminalIdVar)) &&
        !string.IsNullOrWhiteSpace(Get(UsernameVar)) &&
        !string.IsNullOrWhiteSpace(Get(PasswordVar));

    public static SaferPaySettings BuildSettings() => new(
        customerId: Get(CustomerIdVar)!,
        terminalId: Get(TerminalIdVar)!,
        userName: Get(UsernameVar)!,
        passWord: Get(PasswordVar)!,
        sandBox: true);

    private static string? Get(string name) => Environment.GetEnvironmentVariable(name);
}
