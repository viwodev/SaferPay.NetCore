using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SaferPay.Extensions;

public class CustomEnumConverter : StringEnumConverter
{
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Enum değerini al
        var value = reader.Value.ToString();

                    // Enum değeri başında "_" olan değer varsa, "_" karakterini kaldır


        // Enum değeri bir sayı ile başlıyorsa, başına "_" ekle
        if (Char.IsDigit(value[0]))
        {
            value = "_" + value;
        }



        // Normal StringEnumConverter işlevselliğine geri dön
        return base.ReadJson(new JsonTextReader(new System.IO.StringReader(value)), objectType, existingValue, serializer);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        // Enum değerini al
        var enumValue = value.ToString();

        if (enumValue.StartsWith("_"))
        {
            enumValue = enumValue.Substring(1);
        }

        // StringEnumConverter işlevselliğine geri dön
        base.WriteJson(writer, enumValue, serializer);
    }
}
