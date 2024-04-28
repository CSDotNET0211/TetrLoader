using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(BagTypeConverter))]
public enum BagType
{
	Bag7,
	Bag14,
	Pairs,
	Classic,
	TotalMayhem,
	Bag7OO,
	Bag7Plus1,
	Bag7Plus2,
	Bag7PlusX,
}