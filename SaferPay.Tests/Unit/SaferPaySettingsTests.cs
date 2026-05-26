using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class SaferPaySettingsTests
{
    [Fact]
    public void Ctor_WithArguments_AssignsAllFields()
    {
        var s = new SaferPaySettings("cust", "term", "user", "pwd", sandBox: true);

        s.CustomerId.Should().Be("cust");
        s.TerminalId.Should().Be("term");
        s.Username.Should().Be("user");
        s.Password.Should().Be("pwd");
        s.SandBox.Should().BeTrue();
        s.ThrowExceptionOnFail.Should().BeFalse();
    }

    [Fact]
    public void Default_Ctor_LeavesProductionMode()
    {
        new SaferPaySettings().SandBox.Should().BeFalse();
    }

    [Fact]
    public void BaseUri_Switches_OnSandbox()
    {
        var prod = new SaferPaySettings { SandBox = false };
        var test = new SaferPaySettings { SandBox = true };

        prod.BaseUri.Should().Be(new Uri("https://www.saferpay.com/api/"));
        test.BaseUri.Should().Be(new Uri("https://test.saferpay.com/api/"));
    }

    [Fact]
    public void BaseRestUri_Switches_OnSandbox()
    {
        new SaferPaySettings { SandBox = false }.BaseRestUri
            .Should().Be(new Uri("https://www.saferpay.com/"));
        new SaferPaySettings { SandBox = true }.BaseRestUri
            .Should().Be(new Uri("https://test.saferpay.com/"));
    }
}
