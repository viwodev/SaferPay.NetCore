using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;
using SaferPay.Models.Core;

namespace SaferPay.Models.Management;

public class CreateSingleUsePaymentLinkRequest : RestRequestBase
{

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public AddressForm BillingAddressForm { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public CreateSingleUsePaymentLinkConditions? Condition { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ConfigSet { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [Mandatory]
    public DateTime ExpirationDate { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxPaymentAttempts { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Order Order { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [Mandatory]
    public  Payer Payer { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [Mandatory]
    public Payment Payment { get; set; }



    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public RegisterAlias RegisterAlias { get; set; }

}
