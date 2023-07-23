using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(BagTypeConverter))]
public enum SpinBonusesType
{
	None,
	Stupid,
	Handheld,
	All,
	TSpins
}