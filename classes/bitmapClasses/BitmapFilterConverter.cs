using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using static GarlicPress.classes.bitmapClasses.Filters;

namespace GarlicPress.classes.bitmapClasses;
internal class BitmapFilterConverter : JsonConverter<IFilter>
{
    //Gets the correct filter type from the json
    public override IFilter? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            if (root.TryGetProperty("FilterType", out var typeProp))
            {
                var typeString = typeProp.GetString();
                if (FilterTypeMap.TryGetValue(typeString ?? "", out var filterType))
                {
                    return (IFilter?)JsonSerializer.Deserialize(root.GetRawText(), filterType, options) ?? throw new JsonException();
                }
            }
        }
        throw new JsonException();
    }


    //This will add the type of filter to the json so that it can be deserialized into the correct filter type
    public override void Write(Utf8JsonWriter writer, IFilter value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        var filterTypeKey = FilterTypeMap.FirstOrDefault(x => x.Value == value.GetType()).Key;
        if (!string.IsNullOrEmpty(filterTypeKey))
        {
            writer.WriteString("FilterType", filterTypeKey);
        }
        else
        {
            throw new JsonException("Unknown filter type.");
        }

        foreach (var prop in value.GetType().GetProperties())
        {
            var propName = prop.Name;
            var propValue = prop.GetValue(value);

            writer.WritePropertyName(propName);

            JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
        }

        writer.WriteEndObject();
    }

}
