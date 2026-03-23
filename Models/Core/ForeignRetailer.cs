using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

/// <summary>
/// Updated V1.51, Changed CountryCode to Mandatory.
/// </summary>
public class ForeignRetailer
{
    public string City { get; set; }

    [Mandatory]
    public string CountryCode { get; set; }

    public string Name { get; set; }

    public string Street { get; set; }

    public string Zip { get; set; }
}
