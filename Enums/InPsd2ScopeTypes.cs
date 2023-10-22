using Newtonsoft.Json.Converters;

namespace SaferPay.Enums
{
    /// <summary>
    /// Determines if the transaction is in the PSD2 Scope (Payment Service Directive 2 of the European Union)
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum InPsd2ScopeTypes
    {
        YES,
        NO,
        UNKNOWN
    }
}
