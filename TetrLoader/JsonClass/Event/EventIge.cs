using System.Data;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TetrLoader.Enum;
using TetrLoader.Ige;

namespace TetrLoader.JsonClass.Event
{
	public class EventIge : Event, ICloneable
	{
		public EventIge(int? id, int frame, EventType? type, string igeDataRaw) : base(id, frame, type)
		{
			data = JsonSerializer.Deserialize<EventIgeData>(igeDataRaw);
			JsonDocument igeJson = JsonDocument.Parse(igeDataRaw);
			JsonElement igeDataElement = igeJson.RootElement.GetProperty("data");
			string rawDataString = igeDataElement.GetRawText();
			//JsonSerializer.Deserialize<IgeInteraction>(rawDataString);

			string igeType = igeDataElement.GetProperty("type").GetString();
			IgeBase igeBase;

			switch (igeType)
			{
				case "interaction":
					igeBase = JsonSerializer.Deserialize<IgeInteraction>(rawDataString);
					data.data = igeBase;
					break;

				case "interaction_confirm":
					igeBase = JsonSerializer.Deserialize<IgeInteractionConfirm>(rawDataString);

					JsonElement igeInteractionConfirmData = igeDataElement.GetProperty("data");
					string rawInteractionConfirmData = igeInteractionConfirmData.GetRawText();

					string interectionType = igeInteractionConfirmData.GetProperty("type").GetString();
					switch (interectionType)
					{
						case "targeted":
							(igeBase as IgeInteractionConfirm).data =
								JsonSerializer.Deserialize<IgeInteractionConfirmTargetEd>(rawInteractionConfirmData);
							break;

						case "garbage":
							(igeBase as IgeInteractionConfirm).data =
								JsonSerializer.Deserialize<GarbageData>(rawInteractionConfirmData);
							break;

						default: throw new Exception("interectionType:" + interectionType);
					}

					data.data = igeBase;
					break;

				case "target":
					igeBase = JsonSerializer.Deserialize<IgeTarget>(rawDataString);
					data.data = igeBase;
					break;

				case "allow_targeting":
					igeBase = JsonSerializer.Deserialize<IgeAllowTargeting>(rawDataString);
					data.data = igeBase;
					break;

				case "kev":
					igeBase = JsonSerializer.Deserialize<IgeKev>(rawDataString);
					data.data = igeBase;
					try
					{
						JsonElement igeVictimName;
						if (igeDataElement.GetProperty("victim").TryGetProperty("name", out igeVictimName))
							(igeBase as IgeKev).victim =
								JsonSerializer.Deserialize<Victim>((igeDataElement.GetProperty("victim").GetRawText()));
						else
							(igeBase as IgeKev).victim =
								igeDataElement.GetProperty("victim").GetString();
					}
					catch (Exception e)
					{
						Debug.WriteLine("probably not working correctly");
					}

					break;

				case "attack":
					igeBase = JsonSerializer.Deserialize<IgeAllowTargeting>(rawDataString);
					data.data = igeBase;
					break;

				default: throw new Exception("igeType:" + igeType);
			}

			data.data = igeBase;
		}

		public EventIge(int? id, int frame, EventType? type, EventIgeData data) : base(id, frame, type)
		{
			this.data = (EventIgeData)data.Clone();
		}

		public object Clone()
		{
			var data = new EventIge(id, (int)frame, type, (EventIgeData)this.data.Clone());

			return data;
		}


		public new EventIgeData data { get; set; }
	}

	public class EventIgeData : ICloneable
	{
		public int id { get; set; }
		public int frame { get; set; }
		public string? type { get; set; }
		[JsonIgnore] public IgeBase? data { get; set; }

		public object Clone()
		{
			return new EventIgeData()
			{
				id = id,
				frame = frame,
				type = type,
				data = (IgeBase)data.Clone()
			};
		}
	}
}