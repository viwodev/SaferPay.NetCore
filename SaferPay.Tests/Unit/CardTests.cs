using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class CardTests
{
    [Fact]
    public void Ctor_StripsWhitespaceFromNumber()
    {
        var c = new Card("4242 4242 4242 4242", 9, 2030, "123", "John");
        c.Number.Should().Be("4242424242424242");
    }

    [Fact]
    public void Ctor_TwoDigitYear_ExpandsTo20xx()
    {
        var c = new Card("4242424242424242", 12, 30, "123");
        c.ExpYear.Should().Be(2030);
    }

    [Fact]
    public void Ctor_FourDigitYear_IsPreserved()
    {
        var c = new Card("4242424242424242", 12, 2035, "123");
        c.ExpYear.Should().Be(2035);
    }

    [Fact]
    public void ExpYear_Setter_NormalizesTwoDigitInput()
    {
        var c = new Card { ExpYear = 28 };
        c.ExpYear.Should().Be(2028);
    }

    [Fact]
    public void Ctor_NumericVerificationCode_IsStored_AsString()
    {
        var c = new Card("4242424242424242", 1, 2031, 999, "J");
        c.VerificationCode.Should().Be("999");
    }
}
