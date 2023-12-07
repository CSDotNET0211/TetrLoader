using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(GarbageTargetBonusTypeConverter))]
public enum GarbageTargetBonusType
{
	None,
	Offensive,
	Defensive
}