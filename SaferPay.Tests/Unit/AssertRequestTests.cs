using SaferPay.Models.PaymentPage;

namespace SaferPay.Tests.Unit;

public class AssertRequestTests
{
    [Fact]
    public void Ctor_StoresToken()
    {
        new AssertRequest("tok").Token.Should().Be("tok");
    }

    [Fact]
    public void ToString_ContainsToken()
    {
        new AssertRequest("abc").ToString().Should().Contain("abc");
    }
}
