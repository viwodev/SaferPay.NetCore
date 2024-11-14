namespace SaferPay.Models.Core;

public class PaymentOptions
{
    /// <summary>
    /// Indicates the desired transaction type. When set to true the transaction is processed as a pre-authorization otherwise as a final authorization. Please note that not all payment methods support both options and the effective transaction type is determined by Saferpay.
    /// </summary>
    public bool PreAuth { get; set; }

    /// <summary>
    /// When set to true, a transaction might be authorized with an amount less than requested authorization amount.<br/><br/>
    /// <i>* Not all the payment methods support this option.</i><br/>
    /// <i>* This option is currently supported only in Transaction/Initialize and Transaction/AuthorizeDirect.</i><br/>
    /// <i>* Using this option in Transaction/Initialize prevents DCC.</i>
    /// </summary>
    public bool AllowPartialAuthorization { get; set; }
}