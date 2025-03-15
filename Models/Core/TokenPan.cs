using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class TokenPan
{
    /// <summary>
    /// The URL to the image of the payer's physical card.
    /// </summary>
    public string CardImageUrl { get; set; }

    /// <summary>
    /// Month of expiration (eg 4 for April) of the token PAN.
    /// </summary>
    public int ExpMonth { get; set; }

    /// <summary>
    /// Year of expiration of the token PAN.
    /// </summary>
    public int ExpYear { get; set; }

    /// <summary>
    /// The current status of the token PAN by the scheme. If the payer or the issuer terminates the card, the token PAN will be given the status 'DELETED,' and the alias cannot be used for new authorization.
    /// </summary>
    public TokenPanStatus Status { get; set; }

    /// <summary>
    /// Masked number of tokenPAN
    /// </summary>
    public string MaskedNumber { get; set; }
}
