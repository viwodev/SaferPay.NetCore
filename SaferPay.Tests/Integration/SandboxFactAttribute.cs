namespace SaferPay.Tests.Integration;

/// <summary>
/// xUnit <see cref="FactAttribute"/> that auto-skips when sandbox credentials
/// are not configured. Keeps integration tests opt-in without polluting the
/// default test run.
/// </summary>
public sealed class SandboxFactAttribute : FactAttribute
{
    public SandboxFactAttribute()
    {
        if (!SandboxEnvironment.IsAvailable)
        {
            Skip = $"Sandbox credentials not configured. Set {SandboxEnvironment.CustomerIdVar}, "
                 + $"{SandboxEnvironment.TerminalIdVar}, {SandboxEnvironment.UsernameVar}, "
                 + $"{SandboxEnvironment.PasswordVar} to enable.";
        }
    }
}
