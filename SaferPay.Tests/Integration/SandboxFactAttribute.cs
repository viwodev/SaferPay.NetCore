namespace SaferPay.Tests.Integration;

/// <summary>
/// xUnit <see cref="FactAttribute"/> for tests that hit the real SaferPay sandbox.
/// Auto-skips when <see cref="SandboxEnvironment.SkipVar"/> is set, which is the
/// escape hatch for fully-offline runs.
/// </summary>
public sealed class SandboxFactAttribute : FactAttribute
{
    public SandboxFactAttribute()
    {
        if (!SandboxEnvironment.IsAvailable)
        {
            Skip = $"{SandboxEnvironment.SkipVar}=1 set, skipping live-sandbox test.";
        }
    }
}
