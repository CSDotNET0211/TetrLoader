using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class GarbageEntryTypeConverter : JsonConverter<GarbageEntryType>
{
	public override GarbageEntryType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "instant":
				return GarbageEntryType.Instant;
			case "delayed":
				return GarbageEntryType.Delayed;
			case "continuous":
				return GarbageEntryType.Continuous;
			default:
				throw new JsonException("Unknown garbageentry type:"+reader.GetString());
		}
	}

	public override void Write(Utf8JsonWriter writer, GarbageEntryType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case GarbageEntryType.Instant:
				writer.WriteStringValue("instant");
				break;
			case GarbageEntryType.Continuous:
				writer.WriteStringValue("continuous");
				break;
			case GarbageEntryType.Delayed:
				writer.WriteStringValue("delayed");
				break;
			default:
				throw new JsonException("Unknown garbageentry type.");
		}
	}
}