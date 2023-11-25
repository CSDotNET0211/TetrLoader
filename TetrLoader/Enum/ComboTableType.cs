using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(ComboTableTypeConverter))]
public enum ComboTableType
{
	None,
	ClassicGuideLine,
	ModernGuideLine,
	Multiplier
}