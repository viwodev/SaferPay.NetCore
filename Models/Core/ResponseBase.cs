using Newtonsoft.Json;
using SaferPay.Enums;

namespace SaferPay.Models.Core
{
    public abstract class ResponseBase
    {
        public ResponseHeader ResponseHeader { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ResponseStatus ResponseStatus { get; set; } = ResponseStatus.NONE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSuccess
        {
            get
            {
                return (ResponseStatus == ResponseStatus.SUCCESS);
            }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorResponse Error { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public string Json()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }
}
