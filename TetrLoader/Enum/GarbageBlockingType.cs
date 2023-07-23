using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(GarbageBlockingTypeConverter))]
public enum GarbageBlockingType
{
	ComboBlocking,
	LimitedBlocking,
	None
}