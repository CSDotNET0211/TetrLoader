using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class ComboTableTypeConverter : JsonConverter<ComboTableType>
{
	public override ComboTableType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "none":
				return ComboTableType.None;
			case "classic guideline":
				return ComboTableType.ClassicGuideLine;
			case "modern guideline":
				return ComboTableType.ModernGuideLine;
			case "multiplier":
				return ComboTableType.Multiplier;
			default:
				throw new JsonException("Unknown combotable type.");
		}
	}

	public override void Write(Utf8JsonWriter writer, ComboTableType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case ComboTableType.None:
				writer.WriteStringValue("none");
				break;
			case ComboTableType.ClassicGuideLine:
				writer.WriteStringValue("classic guideline");
				break;
			case ComboTableType.ModernGuideLine:
				writer.WriteStringValue("modern guideline");
				break;
			case ComboTableType.Multiplier:
				writer.WriteStringValue("multiplier");
				break;
			default:
				throw new JsonException("Unknown combotable type.");
		}
	}
}