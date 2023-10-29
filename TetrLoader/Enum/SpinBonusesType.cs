using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(SpinBonusesTypeConverter))]
public enum SpinBonusesType
{
	None,
	Stupid,
	Handheld,
	All,
	TSpins
}