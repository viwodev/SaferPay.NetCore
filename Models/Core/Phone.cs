namespace SaferPay.Models.Core;

/// <summary>
/// Phone numbers of the payer<br/><br/>
/// </summary>
/// <remarks>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
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
