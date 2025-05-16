using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;
using SaferPay.Models.Core;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;

namespace SaferPay.Models.Transaction;

public class AuthorizeDirectRequest : RequestBase
{

    public AuthorizeDirectRequest() { }


    /// <summary>
    /// Authentication information for this transaction.
    /// </summary>
    public Authentication Authentication { get; set; }


    /// <summary>
    /// Specify if the transaction was initiated by the merchant (default behavior if not specified) or by the payer. <br/>
    /// This is relevant for most credit and debit cards managed by Mastercard, Visa and American Express card schemes(in card scheme jargon: MERCHANT means MIT, PAYER means CIT). <br/>
    /// For these schemes, transactions initiated by the payer usually require authentication of the card holder, which is not possible if you use Transaction/AuthorizeDirect(use Transaction/Initialize or PaymentPage/Initialize if you're not sure).<br/>
    /// Saferpay will flag the transaction accordingly (also taking the optional Exemption in the Authentication container into account) on the protocols which support this and card issuers might approve or decline transactions depending on this flagging.<br/><br/>
    /// <i>Possible values: MERCHANT, PAYER.</i>
    /// </summary>
    public InitiatorTypes Initiator { get; set; }


    /// <summary>
    /// Optional order information. Only used for payment method Klarna (mandatory) and for Fraud Intelligence (optional).
    /// </summary>
    public Order Order { get; set; }


    /// <summary>
    /// Information on the payer (IP-address)
    /// </summary>
    public Payer Payer { get; set; }


    /// <summary>
    /// Information about the payment (amount, currency, ...)
    /// </summary>
    [Mandatory("Payment is mandatory!")]
    public Payment Payment { get; set; }


    /// <summary>
    /// Information on the means of payment. Important: Only fully PCI certified merchants may directly use the card data.<br/>
    /// If your system is not explicitly certified to handle card data directly, then use the Saferpay Secure Card Data-Storage instead. If the customer enters a new card, you may want to use the Saferpay Hosted Register Form to capture the card data through Saferpay.
    /// </summary>
    [Mandatory("PaymentMeans is mandatory!")]
    public PaymentMeans PaymentMeans { get; set; }


    /// <summary>
    /// Controls whether the given means of payment should be stored inside the Saferpay Secure Card Data storage.
    /// </summary>
    public RegisterAlias RegisterAlias { get; set; }


    /// <summary>
    /// Optional risk factors
    /// </summary>
    public RiskFactors RiskFactors { get; set; }


    /// <summary>
    /// Saferpay Terminal-Id
    /// </summary>
    [Mandatory("TerminalId is mandatory!")]
    public string TerminalId { get; set; }


}
