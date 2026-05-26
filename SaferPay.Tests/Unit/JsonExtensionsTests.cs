using Newtonsoft.Json.Linq;
using SaferPay.Extensions;

namespace SaferPay.Tests.Unit;

public class JsonExtensionsTests
{
    private sealed class Sample
    {
        public string? Name { get; set; }
        public int Value { get; set; }
        public string? Optional { get; set; }
    }

    [Fact]
    public void ToJson_OmitsNullProperties()
    {
        var json = new Sample { Name = "n", Value = 7 }.ToJson();
        var token = JObject.Parse(json);

        token["Name"]!.Value<string>().Should().Be("n");
        token["Value"]!.Value<int>().Should().Be(7);
        token.ContainsKey("Optional").Should().BeFalse();
    }

    [Fact]
    public void FromJson_RoundtripsObject()
    {
        var original = new Sample { Name = "x", Value = 42, Optional = "o" };
        var roundtrip = original.ToJson().FromJson<Sample>();

        roundtrip.Should().NotBeNull();
        roundtrip!.Name.Should().Be("x");
        roundtrip.Value.Should().Be(42);
        roundtrip.Optional.Should().Be("o");
    }
}
