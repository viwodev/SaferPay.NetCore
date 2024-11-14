using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum GenderTypes
{
    [Description("Male")]
    MALE,

    [Description("Female")]
    FEMALE,

    [Description("Diverse")]
    DIVERSE,

    [Description("Company")]
    COMPANY
}
