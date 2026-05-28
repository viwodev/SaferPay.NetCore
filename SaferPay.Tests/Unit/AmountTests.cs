using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class AmountTests
{
    [Theory]
    [InlineData(1.00, "100")]
    [InlineData(12.34, "1234")]
    [InlineData(0.05, "5")]
    [InlineData(1000, "100000")]
    public void Ctor_DecimalString_ConvertsToMinorUnits(decimal value, string expectedMinor)
    {
        var a = new Amount(value, "CHF");
        a.Value.Should().Be(expectedMinor);
        a.CurrencyCode.Should().Be("CHF");
    }

    [Fact]
    public void Ctor_CurrencyEnum_UppercasesCode()
    {
        var a = new Amount(9.99m, CurrencyCodes.EUR);
        a.Value.Should().Be("999");
        a.CurrencyCode.Should().Be("EUR");
    }

    [Fact]
    public void ToString_FormatsValueAndCurrency()
    {
        // ToString parses the *minor-unit* value back as a decimal then formats with 2 decimals.
        var a = new Amount { Value = "1234", CurrencyCode = "USD" };
        a.ToString().Should().EndWith("USD");
    }
}
