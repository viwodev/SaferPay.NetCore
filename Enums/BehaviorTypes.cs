using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum BehaviorTypes
{
    /// <summary>
    /// Do not try again to avoid potential fees related to authorization reattempts that do not respect card schemes instructions. The card issuer will never approve this authorization request.
    /// </summary>
    [Description("Do Not Retry")]
    DO_NOT_RETRY,

    /// <summary>
    /// Request is valid and understood, but can't be processed at this time. This request can be retried.
    /// </summary>
    [Description("Other Means")]
    OTHER_MEANS,

    /// <summary>
    /// This request can be retried later after a certain state/error condition has been changed. For example, insufficient funds (up to 10 attempts in 30 days)
    /// </summary>
    [Description("Retry")]
    RETRY,

    /// <summary>
    /// Special case of retry. Please provide another means of payment.
    /// </summary>
    [Description("Retry Later")]
    RETRY_LATER
}
