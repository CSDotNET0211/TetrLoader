using TetrLoader.Enum;

namespace TetrLoader.JsonClass.Event
{
	public class EventFullOptions : Event
	{
		public EventFullOptions(EventFullOptionsData data) : base(null, null, null)
		{
			this.data = data;
		}

		public new EventFullOptionsData data { get; set; }
	}

	public class EventFullOptionsData
	{
		public int version { get; set; }
		public bool? seed_random { get; set; } = null;

		public double seed { get; set; }
		public bool? allow180 { get; set; } = null;
		public double? g { get; set; } = null;
		public Handling? handling { get; set; } = null;

		public bool? no_szo { get; set; } = null;
		public int? garbagespeed { get; set; } = null;
		public int? garbagecap { get; set; } = null;
		public KicksetType? kickset { get; set; } = null;
		public int? boardwidth { get; set; } = null;
		public int? boardheight { get; set; } = null;
		public int? boardbuffer { get; set; } = null;
		public bool? physical { get; set; } = null;
		public bool? display_username { get; set; } = null;
		public string? username { get; set; } = null;
		public int? nextcount { get; set; } = null;
		public int? stock { get; set; } = null;
		public bool? hasgarbage { get; set; } = null;
		public bool? display_next { get; set; } = null;
		public bool? display_hold { get; set; } = null;
		public int? gmargin { get; set; } = null;
		public int? garbagemargin { get; set; } = null;
		public double? gincrease { get; set; } = null;
		public double? garbagecapincrease { get; set; } = null;
		public int? garbagecapmax { get; set; } = null;
		public double? garbageincrease { get; set; } = null;
		public BagType? bagtype { get; set; } = null;
		public SpinBonusesType? spinbonuses { get; set; } = null;
		public bool? allow_harddrop { get; set; } = null;
		public bool? display_shadow { get; set; } = null;
		public int? locktime { get; set; } = null;
		public int? are { get; set; } = null;
		public int? lineclear_are { get; set; } = null;
		public bool? infinitemovement { get; set; } = null;
		public bool? infinitehold { get; set; } = null;
		public int? lockresets { get; set; } = null;
		public bool? btbchaining { get; set; } = null;
		public bool? clutch { get; set; } = null;
		public PassthroughType? passthrough { get; set; } = null;
		public bool? nolockout { get; set; } = null;
		public GarbageBlockingType? garbageblocking { get; set; } = null;
		public double? garbagemultiplier { get; set; } = null;
		public ComboTableType? combotable { get; internal set; } = null;
		public GarbageTargetBonusType? garbagetargetbonus { get; internal set; } = null;
		public bool? garbageattackcap { get; internal set; } = null;
		public bool? garbagephase { get; internal set; } = null;
		public bool? garbagequeue { get; internal set; } = null;
		public int? garbageholesize { get; internal set; } = null;
		public bool? allclears { get; internal set; } = null;
		public string? garbageentry { get; internal set; } = null;
		public int? garbageare { get; internal set; } = null;
		public bool? shielded { get; internal set; } = null;
	}
}