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
			case "offensive":
				return GarbageTargetBonusType.Offensive;
			case "defensive":
				return GarbageTargetBonusType.Defensive;
			default:
				throw new JsonException("Unknown GarbageTargetBonusType type:"+reader.GetString());
		}
	}

	public override void Write(Utf8JsonWriter writer, GarbageTargetBonusType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case GarbageTargetBonusType.None:
				writer.WriteStringValue("none");
				break;
			case GarbageTargetBonusType.Defensive:
				writer.WriteStringValue("defensive");
				break;
			case GarbageTargetBonusType.Offensive:
				writer.WriteStringValue("offensive");
				break;
			default:
				throw new JsonException("Unknown GarbageTargetBonusType type.");
		}
	}
}