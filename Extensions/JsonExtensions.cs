namespace SaferPay.Extensions;

public static class JsonExtensions
{
    public static string ToJson(this object obj)
    {
        var settings = new Newtonsoft.Json.JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        };

        return Newtonsoft.Json.JsonConvert.SerializeObject(obj, settings);
    }

    public static T FromJson<T>(this string json)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
    }
}
