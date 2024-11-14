using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

public class Klarna
{
    /// <summary>
    /// Klarna extra merchant data (EMD).
    /// </summary>
    [Mandatory]
    public Attachment Attachment { get; set; }
}
