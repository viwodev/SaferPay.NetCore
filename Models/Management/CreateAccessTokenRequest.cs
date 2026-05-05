namespace SaferPay.Models.Management;

public class CreateAccessTokenRequest : RestRequestBase
{
    public string Description { get; set; }

    public List<string> SourceUrls { get; set; }
}
