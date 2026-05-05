using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models.Management;

public class AuthorizationDetails
{
    public DateTime AuthorizationDate { get; set; }
    public DateTime? CaptureDate { get; set; } // Bazı kayıtlarda var, nullable olması güvenli
    public DateTime LastActionDate { get; set; }
    public string Type { get; set; }
    public string State { get; set; }

    [JsonProperty("CapturedMerchantAmount")]
    public AmountInfo CapturedMerchantAmount { get; set; }

    public string MaskedCardNumber { get; set; } // JSON'da mevcut
    public int ExpiryYear { get; set; }
    public int ExpiryMonth { get; set; }
    public bool HasCVC { get; set; }
    public bool HasLiabilityShift { get; set; }
    public string HolderName { get; set; }
    public string CardOrigin { get; set; }
    public string ProcessingAuthCode { get; set; }
    public string AuthorizedBy { get; set; }
    public string CapturedBy { get; set; }
    public bool HasCurrencyConversion { get; set; }

    [JsonProperty("PayerAmount")]
    public AmountInfo PayerAmount { get; set; }

    public bool IsCaptured { get; set; }
    public bool HasPartialCaptures { get; set; }
    public bool IsRefunded { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsOmniChannel { get; set; }
}
