using Newtonsoft.Json;

namespace SaferPay.Models.Core;

/// <summary>
/// May be used to set specific options for some payment methods.
/// </summary>
public class PaymentMethodsOptions
{
    /// <summary>
    /// Optional. Options which only apply to Klarna.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Klarna Klarna { get; set; }
}
