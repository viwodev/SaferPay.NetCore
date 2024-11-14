using Newtonsoft.Json;

namespace SaferPay.Models.Core;

public class PaymentMethodsOptions
{
    /// <summary>
    /// Optional. Options which only apply to IDEAL.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Ideal Ideal { get; set; }

    /// <summary>
    /// Optional. Options which only apply to Klarna.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Klarna Klarna { get; set; }


    /// <summary>
    /// Optional. Options which only apply to account to account
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public A2A A2A { get; set; }
}
