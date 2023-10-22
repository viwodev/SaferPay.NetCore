namespace SaferPay.Models.Core
{
    public abstract class RequestBase
    {
        public RequestHeader RequestHeader { get; set; }

        public string Json()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }
}