using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(PassthroughTypeConverter))]
public enum PassthroughType:byte
{
	Full,
	Limited,
	Zero,
	Consistent
}