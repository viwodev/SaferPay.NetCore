namespace SaferPay.Models.Core;

public class MerchantFundDistributor
{
    /// <summary>
    /// Merchant information required for foreign retailers<br/>
    /// Mandatory for foreign retailers of an international marketplace
    /// </summary>
    public ForeignRetailer ForeignRetailer { get; set; }
}
