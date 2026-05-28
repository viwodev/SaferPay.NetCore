namespace SaferPay.Tests.Unit;

public class CreditCardExpirationTests
{
    [Theory]
    [InlineData(2025, 9, "0925")]
    [InlineData(2030, 12, "1230")]
    [InlineData(99, 1, "0199")] // already 2-digit year
    [InlineData(2000, 7, "0700")]
    public void ToString_FormatsMMYY(int year, int month, string expected)
    {
        new CreditCardExpiration(year, month).ToString().Should().Be(expected);
    }

    [Fact]
    public void Ctor_NormalizesFourDigitYearToTwo()
    {
        var exp = new CreditCardExpiration(2027, 5);
        exp.Year.Should().Be(27);
        exp.Month.Should().Be(5);
    }

    [Theory]
    [InlineData("0925", 9, 25)]
    [InlineData("12/30", 12, 30)]
    [InlineData("01-99", 1, 99)]
    public void Parse_StripsNonDigitsAndExtractsMonthYear(string input, int month, int year)
    {
        var exp = CreditCardExpiration.Parse(input);
        exp.Month.Should().Be(month);
        exp.Year.Should().Be(year);
    }

    [Fact]
    public void Setters_RenormalizeYear()
    {
        var exp = new CreditCardExpiration(2025, 1) { Year = 2031 };
        exp.Year.Should().Be(31);
    }
}
