using Newtonsoft.Json;

namespace SaferPay.Models.Management;

public class Configuration
{

    [JsonProperty("name")]
    public string Name { get; set; }


    [JsonProperty("isDefault")]
    public bool IsDefault { get; set; }


    [JsonProperty("description")]
    public string Description { get; set; }
}
