using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class GarbageTargetBonusTypeConverter : JsonConverter<GarbageTargetBonusType>
{
	public override GarbageTargetBonusType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "none":
				return GarbageTargetBonusType.None;
			case "normal":
				return GarbageTargetBonusType.Normal;
			case "countering":
				return GarbageTargetBonusType.Countering;
			default:
				throw new JsonException("Unknown GarbageTargetBonusType type.");
		}
	}

	public override void Write(Utf8JsonWriter writer, GarbageTargetBonusType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case GarbageTargetBonusType.None:
				writer.WriteStringValue("none");
				break;
			case GarbageTargetBonusType.Countering:
				writer.WriteStringValue("countering");
				break;
			case GarbageTargetBonusType.Normal:
				writer.WriteStringValue("normal");
				break;
			default:
				throw new JsonException("Unknown GarbageTargetBonusType type.");
		}
	}
}