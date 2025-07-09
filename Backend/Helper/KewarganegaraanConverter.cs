using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Models;

namespace Backend.Helper;

public class KewarganegaraanConverter : JsonConverter<Kewarganegaraan>
{
    public override Kewarganegaraan Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var value = reader.GetString();
        return value?.ToUpper() switch
        {
            "WNI" => Kewarganegaraan.WNI,
            "WNA" => Kewarganegaraan.WNA,
            _ => throw new JsonException($"Invalid value for Kewarganegaraan: {value}"),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Kewarganegaraan value,
        JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(value.ToString());
    }
}
