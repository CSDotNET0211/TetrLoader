using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class EventTypeConverter : JsonConverter<EventType>
{
	public override EventType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		switch (reader.GetString())
		{
			case "start":
				return EventType.Start;
			case "end":
				return EventType.End;
			case "full":
				return EventType.Full;
			case "keydown":
				return EventType.Keydown;
			case "keyup":
				return EventType.Keyup;
			case "targets":
				return EventType.Targets;
			case "ige":
				return EventType.Ige;
			case "exit":
				return EventType.Exit;
			default:
				throw new JsonException("Unknown event type.");
		}
	}

	public override void Write(Utf8JsonWriter writer, EventType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case EventType.End:
				writer.WriteStringValue("end");
				return;
			case EventType.Full:
				writer.WriteStringValue("full");
				return;
			case EventType.Ige:
				writer.WriteStringValue("ige");
				return;
			case EventType.Keydown:
				writer.WriteStringValue("keydown");
				return;
			case EventType.Keyup:
				writer.WriteStringValue("keyup");
				return;
			case EventType.Start:
				writer.WriteStringValue("start");
				return;
			case EventType.Targets:
				writer.WriteStringValue("targets");
				return;
			case EventType.Exit:
				writer.WriteStringValue("exit");
				return;
			default:
				throw new JsonException("Unknown event type.");
		}
	}
}