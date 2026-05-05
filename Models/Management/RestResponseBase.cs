using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Models.Management;

public abstract class RestResponseBase
{

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

    public string Json() => Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
}
