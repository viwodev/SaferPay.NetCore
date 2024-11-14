using Newtonsoft.Json;

namespace SaferPay.Models.Core;

public abstract class BasePayment
{
    /// <summary>
    /// <b>Amount <i>![Mandatory]</i></b><br/><br/>
    /// Amount data (currency, value, etc.)<br/>
    /// </summary>
    public Amount Amount { get; set; }

    /// <summary>
    /// A human readable description provided by the merchant that can be displayed in web sites.<br/>
    /// <i>Utf8[1..1000]</i>
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// <b>OrderId <i>+[Recommended]</i></b><br/><br/>
    /// Unambiguous order identifier defined by the merchant / shop. This identifier might be used as reference later on.<br/>
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string OrderId { get; set; }

    /// <summary>
    /// Text which will be printed on payer's debit note. Supported by SIX Acquiring. No guarantee that it will show up on the payer's debit note, because his bank has to support it too.
    /// Please note that maximum allowed characters are rarely supported.It's usually around 10-12.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string PayerNote { get; set; }


    /// <summary>
    /// Mandate reference of the payment. Needed for German direct debits (ELV) only. The value has to be unique.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string MandateId { get; set; }

}
