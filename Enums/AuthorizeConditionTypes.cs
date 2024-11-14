using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum AuthorizeConditionTypes
{
    NONE,
    THREE_DS_AUTHENTICATION_SUCCESSFUL_OR_ATTEMPTED,
    WITH_SUCCESSFUL_THREE_DS_CHALLENGE
}
