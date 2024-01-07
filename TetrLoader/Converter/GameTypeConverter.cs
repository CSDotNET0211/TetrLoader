using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class GameTypeConverter : JsonConverter<GameType>
{
	public override GameType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{ 
			case "40l":
				return GameType.L40;
			case "blitz":
				return GameType.Blitz;
			case "league":
				return GameType.League; 
			default:
				throw new JsonException("Unknown game type:" + reader.GetString());
		}
	}

	public override void Write(Utf8JsonWriter writer, GameType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case GameType.L40:
				writer.WriteStringValue("40l");
				return;
			case GameType.Blitz:
				writer.WriteStringValue("blitz");
				return;
			case GameType.League:
				writer.WriteStringValue("league");
				return;  
			default:
				throw new JsonException("Unknown game type.");
		}
	}
}