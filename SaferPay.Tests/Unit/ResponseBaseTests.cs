using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class ResponseBaseTests
{
    private sealed class FakeResponse : ResponseBase { }

    [Theory]
    [InlineData(ResponseStatus.SUCCESS, true)]
    [InlineData(ResponseStatus.ERROR, false)]
    [InlineData(ResponseStatus.NONE, false)]
    public void IsSuccess_ReflectsStatus(ResponseStatus status, bool expected)
    {
        new FakeResponse { ResponseStatus = status }.IsSuccess.Should().Be(expected);
    }

    [Fact]
    public void Json_RoundtripsAnErrorPayload()
    {
        var r = new FakeResponse
        {
            ResponseStatus = ResponseStatus.ERROR,
            Error = new ErrorResponse { ErrorMessage = "oops" },
        };

        var json = r.Json();
        json.Should().Contain("oops");
    }
}
