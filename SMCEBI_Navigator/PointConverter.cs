using MapBuilder_API_Base;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SMCEBI_Navigator;

public class PointConverter : JsonConverter<PointClass>
{
    public override PointClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                if (root.GetArrayLength() == 2)
                {
                    var x = root[0].GetDouble();
                    var y = root[1].GetDouble();
                    return new PointClass(x, y);
                }
            }
        }

        throw new JsonException("Invalid JSON format for Point.");
    }

    public override void Write(Utf8JsonWriter writer, PointClass value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteEndArray();
    }
}