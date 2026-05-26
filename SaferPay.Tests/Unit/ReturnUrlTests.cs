using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class ReturnUrlTests
{
    [Fact]
    public void ImplicitConversion_FromString_BuildsUri()
    {
        ReturnUrl r = "https://shop/return";
        r.Url.Should().Be(new Uri("https://shop/return"));
    }

    [Fact]
    public void ExplicitConversion_ToString_RoundTrips()
    {
        var r = new ReturnUrl("https://shop/return");
        ((string)r).Should().Be("https://shop/return");
    }

    [Fact]
    public void Ctor_FromUri_PreservesValue()
    {
        var uri = new Uri("https://shop/x");
        new ReturnUrl(uri).Url.Should().BeSameAs(uri);
    }
}
