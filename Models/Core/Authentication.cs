using Newtonsoft.Json;
using SaferPay.Enums;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents authentication details for a transaction, including exemptions, external 3DS data, issuer references, and
/// 3DS challenge options.
/// </summary>
/// <remarks>
/// This class is used to configure authentication-related parameters for a transaction. It supports
/// Strong Customer Authentication (SCA) exemptions, external 3DS solutions, issuer references, and 3DS Secure challenge
/// options.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class Authentication
{


    /// <summary>
    /// Strong Customer Authentication exemption for this transaction.<br/>
    /// Some exemptions are only applicable to payer-initiated transactions and will be ignored otherwise. If you are performing a payer-initiated transaction, make sure you set the 'Initiator' attribute properly (see below).<br/><br/>
    /// Type of Exemption<br/><br/>
    /// <i>Possible values: LOW_VALUE, TRANSACTION_RISK_ANALYSIS, RECURRING</i>
    /// </summary>
    public ExemptionTypes Exemption { get; set; }


    /// <summary>
    /// If you want to use an external 3DS solution, you can provide the authentication data here.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public ExternalThreeDS ExternalThreeDS { get; set; }


    /// <summary>
    /// Contains data that is received from the issuer in the response of a successful payment by other payment providers and will be forwarded to scheme for only this payment.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public IssuerReference IssuerReference { get; set; }


    /// <summary>
    /// 3DS Secure challenge options<br/>
    /// <i>Possible values: FORCE.</i>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public ThreeDsChallengeOptionTypes ThreeDsChallenge { get; set; }


}
