namespace TetrLoader.JsonClass.Event
{
	public class EventFullGame : Event
	{
		public EventFullGame(EventFullGame data) : base(null, null, null)
		{
			this.data = data;
		}

		public new EventFullGame data { get; set; }
	}
	public  class EventFullGameData
	{
		public TetrLoader.JsonClass.Handling? handling { get; set; } = null;



	}
}
