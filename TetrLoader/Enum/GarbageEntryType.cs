using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(GarbageEntryTypeConverter))]
public enum GarbageEntryType
{
	Instant,
	PieceAre,
	Are
}