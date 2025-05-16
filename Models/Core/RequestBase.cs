namespace SaferPay.Models.Core
{
    public abstract class RequestBase
    {
        public RequestHeader RequestHeader { get; set; }

        public string Json()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(this, settings);
        }
    }
}
