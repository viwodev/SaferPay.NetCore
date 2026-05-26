using Newtonsoft.Json.Linq;
using SaferPay.Models.Core;

namespace SaferPay.Tests.Unit;

public class RequestBaseTests
{
    private sealed class FakeRequest : RequestBase
    {
        public string? Visible { get; set; }
        public string? Hidden { get; set; }
    }

    [Fact]
    public void Json_OmitsNullProperties()
    {
        var r = new FakeRequest { Visible = "v" };
        var jo = JObject.Parse(r.Json());
        jo["Visible"]!.Value<string>().Should().Be("v");
        jo.ContainsKey("Hidden").Should().BeFalse();
    }

    [Fact]
    public void Json_IsIndentedByDefault()
    {
        var json = new FakeRequest { Visible = "v" }.Json();
        json.Should().Contain(Environment.NewLine);
    }
}
