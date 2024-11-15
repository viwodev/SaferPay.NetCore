namespace SaferPay.Models.Attributes;

public class MandatoryAttribute : Attribute
{

    public MandatoryAttribute()
    {
    }

    public MandatoryAttribute(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; set; }
}
