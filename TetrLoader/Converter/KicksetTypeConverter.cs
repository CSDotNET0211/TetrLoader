using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class KicksetTypeConverter : JsonConverter<KicksetType>
{
	public override KicksetType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "SRS":
				return KicksetType.SRS;
			case "SRS+":
				return KicksetType.SRSPlus;
			case "NONE":
				return KicksetType.None;
			case "NRS":
				return KicksetType.NRS;
			case "ARS":
				return KicksetType.ARS;
			case "TETRA-X":
				return KicksetType.TETRAX;
			case "SRS-X":
				return KicksetType.SRSX;
			case "ASC":
				return KicksetType.ASC;
			default:
				throw new JsonException("Unknown kickset type.");
		}
	}

	public override void Write(Utf8JsonWriter writer, KicksetType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case KicksetType.None:
				writer.WriteStringValue("NONE");
				return;
			case KicksetType.ARS:
				writer.WriteStringValue("ARS");
				return;
			case KicksetType.ASC:
				writer.WriteStringValue("ASC");
				return;
			case KicksetType.NRS:
				writer.WriteStringValue("NRS");
				return;
			case KicksetType.SRS:
				writer.WriteStringValue("SRS");
				return;
			case KicksetType.SRSPlus:
				writer.WriteStringValue("SRS+");
				return;
			case KicksetType.SRSX:
				writer.WriteStringValue("SRS-X");
				return;
			case KicksetType.TETRAX:
				writer.WriteStringValue("TETRA-X");
				return;
			default:
				throw new JsonException("Unknown kickset type.");
		}
	}
}