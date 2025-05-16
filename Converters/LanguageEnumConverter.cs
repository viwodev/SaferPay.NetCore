using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;

namespace SaferPay.Converters;

public class LanguageEnumConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsEnum || (Nullable.GetUnderlyingType(objectType)?.IsEnum ?? false);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        var enumType = value.GetType();
        var member = enumType.GetMember(value.ToString()).FirstOrDefault();
        var descriptionAttr = member?.GetCustomAttribute<DescriptionAttribute>();

        writer.WriteValue(descriptionAttr?.Description ?? value.ToString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        bool isNullable = Nullable.GetUnderlyingType(objectType) != null;
        var enumType = Nullable.GetUnderlyingType(objectType) ?? objectType;

        if (reader.TokenType == JsonToken.Null)
        {
            if (!isNullable)
                throw new JsonSerializationException($"Cannot convert null value to {objectType}.");
            return null;
        }

        if (reader.TokenType != JsonToken.String)
            throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing enum.");

        var description = reader.Value.ToString();

        foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attr = field.GetCustomAttribute<DescriptionAttribute>();
            if ((attr != null && attr.Description == description) || field.Name.Equals(description, StringComparison.OrdinalIgnoreCase))
            {
                return Enum.Parse(enumType, field.Name);
            }
        }

        throw new JsonSerializationException($"Unknown description '{description}' for enum '{enumType.Name}'.");
    }
}
