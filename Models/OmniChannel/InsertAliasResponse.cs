using SaferPay.Models.Core;

namespace SaferPay.Models.OmniChannel;

/// <summary>
/// InsertAlias Response
/// </summary>
public class InsertAliasResponse : ResponseBase
{
    /// <summary>
    /// Information about the registered alias.
    /// </summary>
    public Alias Alias { get; set; }

    /// <summary>
    /// Information about the registered means of payment
    /// </summary>
    public PaymentMeans PaymentMeans { get; set; }

}
