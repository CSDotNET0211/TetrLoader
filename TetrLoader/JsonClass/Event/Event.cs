using TetrLoader.Enum;

namespace TetrLoader.JsonClass.Event
{
	public class Event
	{
		public Event(int? id, int? frame, EventType? type)
		{
			this.id = id;
			this.frame = frame;
			this.type = type;
			this.data = null;
		}

		public int? id { get; set; }
		public int? frame { get; set; }
		public EventType? type { get; set; }
		public object? data { get; set; }
	}
}
