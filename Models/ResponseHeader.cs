using Newtonsoft.Json;

namespace SaferPay.Models
{
    public class ResponseHeader
    {
        public string SpecVersion { get; set; }
        public string RequestId { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}