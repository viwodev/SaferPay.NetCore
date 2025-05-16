using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;
using SaferPay.Models.PaymentPage;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents a form for entering card details, including optional customization for holder name and verification code
/// fields.
/// </summary>
/// <remarks>The <see cref="CardForm"/> class allows customization of the card entry form by enabling or disabling
/// specific fields, such as the holder name and verification code. These fields can be configured to be mandatory or
/// omitted entirely, depending on the requirements of the payment process.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class CardForm
{
    /// <summary>
    /// This parameter lets you customize the holder name field on the card entry form. Per default, a holder name field is not shown.<br/><br/>
    /// </summary>
    /// <remarks>
    /// Possible values:
    /// <list type="bullet">
    /// <item><see cref="HolderNameTypes.NONE"/></item>
    /// <item><see cref="HolderNameTypes.MANDATORY"/></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// Example: MANDATORY
    /// </example>
    /// <value>
    /// <see cref="HolderNameTypes"/>
    /// </value>
    [Mandatory("HolderName field is required.")]
    [FieldUsage(typeof(InitializePaymentPageRequest))]
    public HolderNameTypes HolderName { get; set; }

    /// <summary>
    /// This parameter can be used to display an entry form to request Verification Code (CVV, CVC) in case that an alias is used as PaymentMeans. Note that not all brands support Verification Code.<br/><br/>
    /// </summary>
    /// <remarks>
    /// Possible values:
    /// <list type="bullet">
    /// <item><see cref="VerificationCodeTypes.NONE"/></item>
    /// <item><see cref="VerificationCodeTypes.MANDATORY"/></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// Example: MANDATORY
    /// </example>
    /// <value>
    /// <see cref="VerificationCodeTypes"/>
    /// </value>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public VerificationCodeTypes VerificationCode { get; set; }
}
