using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(PassthroughTypeConverter))]
public enum PassthroughType
{
	Full,
	Limited,
	Zero,
	Consistent
}