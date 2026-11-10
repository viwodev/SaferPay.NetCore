namespace SaferPay.Models.Core;

/// <summary>
/// Payment data from Klarna (API 1.55).<br/>
/// Used in <c>Transaction/Initialize</c> to link the payment to an active Klarna network session.
/// </summary>
public class KlarnaPaymentMeans
{
    public KlarnaPaymentMeans() { }

    public KlarnaPaymentMeans(string klarnaNetworkSessionToken, string klarnaNetworkData = null)
    {
        KlarnaNetworkSessionToken = klarnaNetworkSessionToken;
        KlarnaNetworkData = klarnaNetworkData;
    }

    /// <summary>
    /// Additional data to enable custom features or data exchange as supported by Klarna via <c>klarna_network_data</c>.<br/><br/>
    /// <i>String length: inclusive between 0 and 10240</i>
    /// </summary>
    public string KlarnaNetworkData { get; set; }

    /// <summary>
    /// <b>KlarnaNetworkSessionToken <i>![Mandatory]</i></b>
    /// The Klarna-issued token <c>klarna_network_session_token</c> that represents an active network session.
    /// Used to securely link interactions across payments, express checkout, sign-in with Klarna, On-site messaging and prequalification.<br/><br/>
    /// <i>String length: inclusive between 1 and 8092</i><br/>
    /// <strong>Mandatory</strong>
    /// </summary>
    public string KlarnaNetworkSessionToken { get; set; }
}
