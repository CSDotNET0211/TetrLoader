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


	public class EventFullGameData
	{
		public object? board { get; set; }
		public List<string>? bag { get; set; }
		public double? g { get; set; }
		public bool? playing { get; set; }
		public Hold? hold { get; set; }
		public string? piece { get; set; }
		public Handling? handling { get; set; } = null;
	}
}