using SaferPay.Models.Core;

namespace SaferPay.Models.Management;

public class ManagementBaseResponse : RestResponseBase
{
    public List<ManagementFeature> Features { get; set; }

    public ManagementPackage Package { get; set; }
}
