using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class BagTypeConverter : JsonConverter<BagType>
{
	public override BagType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "7-bag":
			case "7bag":
				return BagType.Bag7;
			case "14-bag":
				return BagType.Bag14;
			case "classic":
				return BagType.Classic;
			case "pairs":
				return BagType.Pairs;
			case "total mayhem":
				return BagType.TotalMayhem;
			case "7+1-bag":
				return BagType.Bag7Plus1;
			case "7+2-bag":
				return BagType.Bag7Plus2;
			case "7+x-bag":
				return BagType.Bag7PlusX;
			default:
				throw new JsonException("Unknown bag type:" + reader.GetString());
		}
	}

	public override void Write(Utf8JsonWriter writer, BagType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case BagType.Bag7:
				writer.WriteStringValue("7-bag");
				return;
			case BagType.Bag14:
				writer.WriteStringValue("14-bag");
				return;
			case BagType.Classic:
				writer.WriteStringValue("classic");
				return;
			case BagType.Pairs:
				writer.WriteStringValue("pairs");
				return;
			case BagType.TotalMayhem:
				writer.WriteStringValue("total mayhem");
				return;
			case BagType.Bag7Plus1:
				writer.WriteStringValue("7+1-bag");
				return;
			case BagType.Bag7Plus2:
				writer.WriteStringValue("7+2-bag");
				return;
			case BagType.Bag7PlusX:
				writer.WriteStringValue("7+x-bag");
				return;
			default:
				throw new JsonException("Unknown bag type.");
		}
	}
}