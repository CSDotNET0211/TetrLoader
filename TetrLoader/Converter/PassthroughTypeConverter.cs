﻿using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.Converter;

public class PassthroughTypeConverter : JsonConverter<PassthroughType>
{
	public override PassthroughType Read(ref Utf8JsonReader reader, Type typeToConvert,
		JsonSerializerOptions options)
	{
		try
		{
			var value = reader.GetBoolean();
			if (value)
				return PassthroughType.Full;
			else return PassthroughType.Limited;
		}
		catch
		{
			switch (reader.GetString())
			{
				case "zero":
					return PassthroughType.Zero;
				case "consistent":
					return PassthroughType.Consistent;
				case "limited":
					return PassthroughType.Limited;
				case "full":
					return PassthroughType.Full;
				case "true":
				case "True":
					return PassthroughType.Full;
				case "false":
				case "False":
					return PassthroughType.Limited;
				default:
					throw new JsonException("Unknown passthrough type.");
			}
		}
	}

	public override void Write(Utf8JsonWriter writer, PassthroughType value, JsonSerializerOptions options)
	{
		switch (value)
		{
			case PassthroughType.Consistent:
				writer.WriteStringValue("consistent");
				return;
			case PassthroughType.Full:
				writer.WriteStringValue("full");
				return;
			case PassthroughType.Limited:
				writer.WriteStringValue("limited");
				return;
			case PassthroughType.Zero:
				writer.WriteStringValue("zero");
				return;

			default:
				throw new JsonException("Unknown passthrough type.");
		}
	}
}