using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class GarbageBlockingTypeConverter : JsonConverter<GarbageBlockingType>
{
	public override GarbageBlockingType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "combo blocking":
				return GarbageBlockingType.ComboBlocking;
			case "limited blocking":
				return GarbageBlockingType.LimitedBlocking;
			case "none":
				return GarbageBlockingType.None;
			default:
				throw new JsonException("Unknown garbage blocking type.");
		}
	}

	public override void Write(Utf8JsonWriter writer, GarbageBlockingType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case GarbageBlockingType.None:
				writer.WriteStringValue("none");
				return;
			case GarbageBlockingType.ComboBlocking:
				writer.WriteStringValue("combo blocking");
				return;
			case GarbageBlockingType.LimitedBlocking:
				writer.WriteStringValue("limited blocking");
				return;
			default:
				throw new JsonException("Unknown garbage blocking type.");
		}
	}
}