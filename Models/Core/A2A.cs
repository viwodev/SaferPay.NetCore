namespace SaferPay.Models.Core;

public class A2A
{
    /// <summary>
    /// The account holder name will be used if not already present in the authorization.<br/>
    /// If no account holder name is present in the authorization and none provided in the refund request, the refund cannot be processed.<br/><br/>
    /// <i>Utf8[1..50]<br/> 
    /// Example: John Doe</i>
    /// </summary>
    public string AccountHolderName { get; set; }
}
