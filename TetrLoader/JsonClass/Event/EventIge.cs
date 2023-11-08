using TetrLoader.Enum;

namespace TetrLoader.JsonClass.Event
{ 
	public class EventIge : Event, ICloneable
	{
		public EventIge(int? id, int frame, EventType? type, EventIgeData data) : base(id, frame, type)
		{
			this.data = data;
		}

		public new EventIgeData data { get; set; }

		public object Clone()
		{
			var data = new EventIge(id, (int)frame, type, (EventIgeData)this.data.Clone());

			return data;
		}
	}
	 
	public class EventIgeData : ICloneable
	{
		public int? id { get; set; }
		public int frame { get; set; }
		public string? type { get; set; }
		public IgeData? data { get; set; }

		public object Clone()
		{
			return new EventIgeData()
			{
				id = id,
				frame = frame,
				type = type,
				data = data?.Clone()
			};
		}
	}
}