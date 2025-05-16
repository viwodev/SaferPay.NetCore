using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

/// <summary>
/// Issuer reference information
/// </summary>
public class IssuerReference
{


    /// <summary>
    /// SCA transaction settlement date, created by the card issuer. For MasterCard schemes only.<br/><br/>
    /// <i>String length: inclusive between 4 and 4</i><br/>
    /// <i>Example: 0122</i>
    /// </summary>
    public string SettlementDate { get; set; }


    /// <summary>
    /// SCA transaction stamp, created by the card issuer<br/><br/>
    /// <i>Max length: 50</i><br/>
    /// <i>Example: 9406957728464714731817</i>
    /// </summary>
    [Mandatory("TransactionStamp is required!")]
    public string TransactionStamp { get; set; }


}
