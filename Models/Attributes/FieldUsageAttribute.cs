namespace SaferPay.Models.Attributes;

public class FieldUsageAttribute : Attribute
{

    public FieldUsageAttribute()
    {
    }

    public FieldUsageAttribute(params Type[] usages)
    {
        this.FieldNames = usages.ToList();
    }

    public List<Type> FieldNames { get; set; } = new List<Type>();
}
