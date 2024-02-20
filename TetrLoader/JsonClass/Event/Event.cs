using System.Text.Json.Serialization;
using TetrLoader.Enum;

namespace TetrLoader.JsonClass.Event
{ 
	public class Event : ICloneable
	{
		public Event(int? id, int? frame, EventType? type)
		{
			this.id = id;
			this.frame = frame;
			this.type = type;
			data = null;
		}
		
		public object Clone()
		{
			Event obj = new Event(id, frame, type);
			return obj;
		}

		public int? id { get; set; }
		public int? frame { get; set; }
		public EventType? type { get; set; }
		public object? data { get; set; }
	}
}