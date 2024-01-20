using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class KeyTypeConverter : JsonConverter<KeyType>
{
	public override KeyType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "moveLeft":
				return KeyType.MoveLeft;
			case "moveRight":
				return KeyType.MoveRight;
			case "softDrop":
				return KeyType.SoftDrop;
			case "hardDrop":
				return KeyType.HardDrop;
			case "hold":
				return KeyType.Hold;
			case "rotateCW":
				return KeyType.RotateCW;
			case "rotateCCW":
				return KeyType.RotateCCW;
			case "rotate180":
				return KeyType.Rotate180;
			case "chat":
				return KeyType.Chat;
			case "retry":
				return KeyType.Retry;
			case "exit":
				return KeyType.Exit;
			default:
				if (reader.GetString().StartsWith("target"))
					return KeyType.Null;

				throw new JsonException("Unknown key type:" + reader.GetString());
		}
	}

	public override void Write(Utf8JsonWriter writer, KeyType value, JsonSerializerOptions options)
	{
		var keystr = value.ToString();
		char firstChar = keystr[0];
		string restOfString = keystr.Substring(1);
		string result = char.ToLower(firstChar) + restOfString;
		writer.WriteStringValue(result);
	}
}