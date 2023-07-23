using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
	Start,
	End,
	Full,
	Keydown,
	Keyup,
	Targets,
	Ige
}