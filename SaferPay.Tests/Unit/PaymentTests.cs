using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class PaymentTests
{
    [Fact]
    public void Ctor_Decimal_BuildsAmountAndOrderId()
    {
        var p = new Payment(19.95m, "CHF", "order-1");
        p.OrderId.Should().Be("order-1");
        p.Amount.Should().NotBeNull();
        p.Amount.Value.Should().Be("1995");
        p.Amount.CurrencyCode.Should().Be("CHF");
    }

    [Fact]
    public void Ctor_CurrencyEnum_UppercasesCode()
    {
        var p = new Payment(50m, CurrencyCodes.USD, "o");
        p.Amount.CurrencyCode.Should().Be("USD");
        p.Amount.Value.Should().Be("5000");
    }

    [Fact]
    public void Ctor_AmountAsString_StripsSeparators()
    {
        var p = new Payment("1 234.56", "EUR", "o2");
        p.Amount.Value.Should().Be("123456");
        p.Amount.CurrencyCode.Should().Be("EUR");
    }
}
