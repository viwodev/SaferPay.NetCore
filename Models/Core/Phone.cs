namespace SaferPay.Models.Core;

/// <summary>
/// 
/// </summary>
public class Phone
{
    /// <summary>
    /// The payer's main phone number<br/><br/>
    /// <i>Example: +41 12 345 6789</i>
    /// </summary>
    public string Main { get; set; }

    /// <summary>
    /// The payer's mobile number<br/><br/>
    /// <i>Example: +41 12 345 6789</i>
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// The payer's work phone number<br/><br/>
    /// <i>Example: +41 12 345 6789</i>
    /// </summary>
    public string Work { get; set; }
}
