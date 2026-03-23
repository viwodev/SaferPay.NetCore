using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

/// <summary>
/// Updated V1.51
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum CheckResultTypes
{
    OK,
    NOT_PERFORMED
}
