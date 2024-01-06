using System.Runtime.InteropServices;
using System.Text.Json;

namespace TetrLoader;

public class Util
{
	class ForMulti
	{
		public bool? ismulti { get; set; }
	}

	public static bool IsMulti(ref string jsonString)
	{
		var instance = JsonSerializer.Deserialize<ForMulti>(jsonString);
		if (instance.ismulti != null)
			return (bool)instance.ismulti;
		else
			return false;
	}

	public static string GetIgeDataType(ref string igeJsonString)
	{
		JsonDocument json = JsonDocument.Parse(igeJsonString);
		if (json.RootElement.TryGetProperty("data.type", out JsonElement typeString))
			return typeString.GetString();
		else
			throw new Exception("unknown type");
	}

	public static string GetUsername(ref string fullDataString)
	{
		JsonDocument json = JsonDocument.Parse(fullDataString);
		JsonElement usernameString;
		if (!json.RootElement.GetProperty("options").TryGetProperty("username", out usernameString))
			json.RootElement.GetProperty("options").GetProperty("user").TryGetProperty("username", out usernameString);

		return usernameString.GetString();
	}
}