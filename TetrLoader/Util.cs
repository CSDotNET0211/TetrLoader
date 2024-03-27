using System.Runtime.InteropServices;
using System.Text.Json;
using TetrLoader.Enum;
using TetrLoader.JsonClass.Event;

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

	public static string GetUsernameFromFullData(EventFullOptionsData fullDataOptionsData)
	{
		string? username = fullDataOptionsData.username;
		username ??= fullDataOptionsData.user.username;
		return username;
	}

	/// <summary>
	/// nested data is still string
	/// </summary>
	/// <returns></returns>
	public static Event ProcessEvent(Event @event)
	{
		switch (@event.type)
		{
			case EventType.Start:
				return @event;

			case EventType.End:
				return new EventEnd
				(
					@event.id,
					(int)@event.frame,
					@event.type,
					JsonSerializer.Deserialize<EventEndData>(@event.data.ToString())
				);

			case EventType.Full:
				return new EventFull
				(
					@event.id,
					(int)@event.frame,
					@event.type,
					JsonSerializer.Deserialize<EventFullData>(@event.data.ToString())
				);

			case EventType.Keyup:
			case EventType.Keydown:
				return new EventKeyInput
				(
					@event.id,
					(int)@event.frame,
					@event.type,
					JsonSerializer.Deserialize<EventKeyInputData>(@event.data.ToString())
				);

			case EventType.Targets:
				return new EventTargets(
					@event.id,
					(int)@event.frame,
					@event.type,
					JsonSerializer.Deserialize<EventTargetsData>(@event.data.ToString())
				);

			case EventType.Ige:
				return new EventIge(
					@event.id,
					(int)@event.frame,
					@event.type,
					@event.data.ToString()
				);

			default:
				return @event;
		}
	}
}