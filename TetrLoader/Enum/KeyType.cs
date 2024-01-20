using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(KeyTypeConverter))]
public enum KeyType
{
	MoveLeft,
	MoveRight,
	SoftDrop,
	RotateCCW,
	RotateCW,
	Rotate180,
	HardDrop,
	Hold,
	Chat,
	Exit,
	Retry,
	Null
}