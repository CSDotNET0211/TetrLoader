using System.Text.Json.Serialization;
using TetrLoader.Converter;

namespace TetrLoader.Enum;

[JsonConverter(typeof(KicksetTypeConverter))]
public enum KicksetType
{
	SRS,
	SRSPlus,
	SRSX,
	TETRAX,
	NRS,
	ARS,
	ASC,
	None
}