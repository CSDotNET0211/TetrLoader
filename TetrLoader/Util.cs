using System.Runtime.InteropServices;
using System.Text.Json;

namespace TetrLoader;

public class Util
{
	public static bool IsMulti(ref string jsonString)
	{
		JsonDocument json = JsonDocument.Parse(jsonString);
		if (json.RootElement.TryGetProperty("ismulti", out JsonElement ismulti))
			return ismulti.GetBoolean();
		else
			return false;
	}

	public static string GetIgeDataType(ref string igeJsonString)
	{
		JsonDocument json = JsonDocument.Parse(igeJsonString);
		Console.WriteLine(Marshal.SizeOf(json));
		if (json.RootElement.TryGetProperty("data.type", out JsonElement typeString))
			return typeString.GetString();
		else
			throw new Exception("unknown type");
	}
}