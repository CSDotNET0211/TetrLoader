using TetrLoader.Enum;

namespace TetrLoader.JsonClass.Event
{
	 
	public class EventKeyInput : Event
	{
		public EventKeyInput(int? id, int frame, EventType? type, EventKeyInputData data) : base(id, frame, type)
		{
			this.data = data;
		}

		public new EventKeyInputData data { get; set; }
	}

	 
	public class EventKeyInputData
	{
		public KeyType key { get; set; }
		public double subframe { get; set; }
		public bool hoisted { get; set; }
	}
}