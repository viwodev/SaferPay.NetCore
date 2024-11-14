namespace SaferPay.Models.Core;

public class Attachment
{
    /// <summary>
    /// Klarna extra merchant data (EMD).<br/><br/>
    /// <i>Check Klarna's EMD documentation for further details.</i>
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Content type of the attachment<br/><br/>
    /// <i>Utf8[1..1000]</i>
    /// </summary>
    public string ContentType { get; set; }
}
