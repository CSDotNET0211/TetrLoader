using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(GarbageStatusConverter))]
public enum GarbageStatus
{
	Sleeping,
	Caution,
	Spawn,
	Danger
}