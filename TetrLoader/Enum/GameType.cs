using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(GameTypeConverter))]
public enum GameType
{
	League,
	Blitz,
	L40
}