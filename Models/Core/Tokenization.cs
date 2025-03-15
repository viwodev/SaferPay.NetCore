using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class Tokenization
{
    /// <summary>
    /// The system used to tokenize the payment means.
    /// </summary>
    public string Program { get; set; }

    /// <summary>
    /// The current state of the tokenization of payment means.
    /// </summary>
    public TokenizationStatus Status { get; set; }

    /// <summary>
    /// Contains information about the returned token PAN from the scheme for card payment means. It will only be returned when the tokenization is SUCCESSFUL.
    /// </summary>
    public TokenPan TokenPan { get; set; }
}
