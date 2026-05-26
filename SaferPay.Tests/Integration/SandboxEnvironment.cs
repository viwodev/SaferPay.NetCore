using SaferPay.Models.Core;

namespace SaferPay.Tests.Integration;

/// <summary>
/// Resolves SaferPay sandbox credentials for integration tests.
///
/// Lookup order:
/// 1. Environment variables (SAFERPAY_CUSTOMER_ID / TERMINAL_ID / USERNAME / PASSWORD)
///    — lets users / forks override with their own sandbox account.
/// 2. The public Viwo sandbox account, already published in this repository at
///    SaferPay.Test/TestConfig.cs. Mirrored here so CI can exercise the real HTTP
///    pipeline against test.saferpay.com on every PR without provisioning secrets.
///
/// Escape hatch: setting SAFERPAY_SKIP_INTEGRATION=1 (e.g. for fully-offline runs)
/// makes IsAvailable return false and the SandboxFact attribute skip the tests.
/// </summary>
internal static class SandboxEnvironment
{
    public const string CustomerIdVar = "SAFERPAY_CUSTOMER_ID";
    public const string TerminalIdVar = "SAFERPAY_TERMINAL_ID";
    public const string UsernameVar = "SAFERPAY_USERNAME";
    public const string PasswordVar = "SAFERPAY_PASSWORD";
    public const string SkipVar = "SAFERPAY_SKIP_INTEGRATION";

    // Public sandbox account shipped by Viwo with the playground. Same values as
    // SaferPay.Test/TestConfig.cs. Not a secret — already committed on main.
    private const string DefaultCustomerId = "268079";
    private const string DefaultTerminalId = "17757286";
    private const string DefaultUsername = "API_268079_69541955";
    private const string DefaultPassword = "!S4f3Rp4%y?0_T35T";

    public static bool IsAvailable
    {
        get
        {
            if (string.Equals(Get(SkipVar), "1", StringComparison.Ordinal)) return false;
            // Defaults always satisfy the contract, so the only way to be unavailable
            // is the explicit skip opt-out above.
            return true;
        }
    }

    public static SaferPaySettings BuildSettings() => new(
        customerId: Get(CustomerIdVar) ?? DefaultCustomerId,
        terminalId: Get(TerminalIdVar) ?? DefaultTerminalId,
        userName: Get(UsernameVar) ?? DefaultUsername,
        passWord: Get(PasswordVar) ?? DefaultPassword,
        sandBox: true);

    private static string? Get(string name)
    {
        var v = Environment.GetEnvironmentVariable(name);
        return string.IsNullOrWhiteSpace(v) ? null : v;
    }
}
