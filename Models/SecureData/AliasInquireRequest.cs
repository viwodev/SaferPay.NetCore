using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData;

public class AliasInquireRequest : RequestBase
{
    /// <summary>
    /// 
    /// </summary>
    public string AliasId { get; set; }
}
