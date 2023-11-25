using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class GarbageStatusConverter : JsonConverter<GarbageStatus>
{
	public override GarbageStatus Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "caution":
				return GarbageStatus.Caution;
			case "sleeping":
				return GarbageStatus.Sleeping;
			case "spawn":
				return GarbageStatus.Spawn;
			case "danger":
				return GarbageStatus.Danger;
			default:
				throw new JsonException("Unknown garbagestatus:" + reader.GetString());
		}
	}

	public override void Write(Utf8JsonWriter writer, GarbageStatus value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case GarbageStatus.Caution:
				writer.WriteStringValue("caution");
				return;
			case GarbageStatus.Sleeping:
				writer.WriteStringValue("sleeping");
				return;
			case GarbageStatus.Danger:
				writer.WriteStringValue("danger");
				return;
			case GarbageStatus.Spawn:
				writer.WriteStringValue("spawn");
				return;
			default:
				throw new JsonException("Unknown garbagestatus.");
		}
	}
}