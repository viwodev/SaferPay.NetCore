using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

public class CardForm
{
    /// <summary>
    /// This parameter lets you customize the holder name field on the card entry form. Per default, a holder name field is not shown.<br/><br/>
    /// <i>Possible values: NONE, MANDATORY.</i>
    /// </summary>
    [Mandatory]
    public HolderNameTypes HolderName { get; set; }

    /// <summary>
    /// This parameter can be used to display an entry form to request Verification Code (CVV, CVC) in case that an alias is used as PaymentMeans. Note that not all brands support Verification Code.<br/><br/>
    /// <i>Possible values: NONE, MANDATORY.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public VerificationCodeTypes VerificationCode { get; set; }
}
