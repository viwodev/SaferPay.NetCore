using SaferPay.Extensions;
using SaferPay.Models.PaymentPage;
using SaferPay.Models.Transaction;

namespace SaferPay.Tests.Unit;

/// <summary>
/// API 1.55: <c>PaymentAccountReference</c> is returned under <c>PaymentMeans.Card</c>,
/// which maps to <see cref="Models.Core.Card"/> or <see cref="Models.Core.AuthorizationCard"/> depending on the response.
/// </summary>
public class PaymentAccountReferenceTests
{
    private const string Json = """
        { "PaymentMeans": { "Card": { "MaskedNumber": "49999999xxxx0004", "PaymentAccountReference": "V0010013022298169667651347248" } } }
        """;

    [Fact]
    public void AuthorizeResponse_MapsPaymentAccountReference()
    {
        var res = Json.FromJson<AuthorizeResponse>();

        res.PaymentMeans.Card.PaymentAccountReference.Should().Be("V0010013022298169667651347248");
    }

    [Fact]
    public void PaymentPageAssertResponse_MapsPaymentAccountReference()
    {
        var res = Json.FromJson<AssertResponse>();

        res.PaymentMeans.Card.PaymentAccountReference.Should().Be("V0010013022298169667651347248");
    }
}
