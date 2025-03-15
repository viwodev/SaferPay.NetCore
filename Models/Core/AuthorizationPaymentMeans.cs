namespace SaferPay.Models.Core;

public class AuthorizationPaymentMeans
{
    /// <summary>
    /// Brand information<br/><br/>
    /// <strong>Mandatory</strong>
    /// </summary>
    public Brand Brand { get; set; }

    /// <summary>
    /// Means of payment formatted / masked for display purposes<br/><br/>
    /// <i>Example: DisplayText</i>
    /// <strong>Mandatory</strong>
    /// </summary>
    public string DisplayText { get; set; }

    /// <summary>
    /// Name of Wallet, if the transaction was done by a wallet
    /// </summary>
    public string Wallet { get; set; }

    /// <summary>
    /// Card data
    /// </summary>
    public AuthorizationCard Card { get; set; }

    /// <summary>
    /// Bank account data for direct debit transactions.
    /// </summary>
    public BankAccount BankAccount { get; set; }

    /// <summary>
    /// PayPal data
    /// </summary>
    public PayPal PayPal { get; set; }

}