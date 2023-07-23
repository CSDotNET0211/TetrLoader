using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class SpinBonusesTypeConverter : JsonConverter<SpinBonusesType>
{
	public override SpinBonusesType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "none":
				return SpinBonusesType.None;
			case "stupid":
				return SpinBonusesType.Stupid;
			case "handheld":
				return SpinBonusesType.Handheld;
			case "all":
				return SpinBonusesType.All;
			case "T-spins":
				return SpinBonusesType.TSpins;
			default:
				throw new JsonException("Unknown spinbonuses type.");
		}
	}

	public override void Write(Utf8JsonWriter writer, SpinBonusesType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case SpinBonusesType.All:
				writer.WriteStringValue("all");
				break;
			case SpinBonusesType.TSpins:
				writer.WriteStringValue("T-spins");
				break;
			case SpinBonusesType.Handheld:
				writer.WriteStringValue("handheld");
				break;
			case SpinBonusesType.None:
				writer.WriteStringValue("none");
				break;
			case SpinBonusesType.Stupid:
				writer.WriteStringValue("stupid");
				break;
			default:
				throw new JsonException("Unknown spinbonuses type.");
		}
	}
}