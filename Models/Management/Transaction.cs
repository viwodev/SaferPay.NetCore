using Newtonsoft.Json;

namespace SaferPay.Models.Management;

public class Transaction
{
    [JsonProperty("MerchantAmount")]
    public AmountInfo MerchantAmount { get; set; }

    public int CustomerId { get; set; }
    public int TerminalId { get; set; }
    public string TerminalType { get; set; }
    public string Application { get; set; }
    public string TransactionId { get; set; }
    public string OrderId { get; set; }
    public string Provider { get; set; }
    public string PaymentMethod { get; set; }
    public string IpAddress { get; set; }
    public string IpOrigin { get; set; } // JSON'da var, ekledim
    public string Description { get; set; }
    public AuthorizationDetails AuthorizationDetails { get; set; }
}

public class AmountInfo
{
    [JsonProperty("Value")]
    public string Value { get; set; } // "17.50"

    [JsonProperty("CurrencyCode")]
    public string CurrencyCode { get; set; } // "TRY"
}
