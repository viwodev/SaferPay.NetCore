using System.Net;
using SaferPay.Enums;
using SaferPay.Exceptions;
using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class SaferPayExceptionTests
{
    [Fact]
    public void Ctor_BuildsRichMessage_WithStatusAndError()
    {
        var error = new ErrorResponse
        {
            ErrorName = ErrorNames.VALIDATION_FAILED,
            ErrorMessage = "bad input",
            ErrorDetail = new[] { "field=Amount", "field=TerminalId" },
        };

        var ex = new SaferPayException(HttpStatusCode.BadRequest, error);

        ex.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
        ex.ErrorResponse.Should().BeSameAs(error);
        ex.Message.Should().Contain("BadRequest");
        ex.Message.Should().Contain("bad input");
        ex.Message.Should().Contain("field=Amount");
        ex.Message.Should().Contain("field=TerminalId");
    }

    [Fact]
    public void Ctor_HandlesNullErrorDetail()
    {
        var ex = new SaferPayException(HttpStatusCode.InternalServerError,
            new ErrorResponse { ErrorMessage = "boom" });

        ex.Message.Should().Contain("InternalServerError");
        ex.Message.Should().Contain("boom");
    }
}
