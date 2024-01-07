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
		public bool? seed_random { get; set; }  

		public double seed { get; set; }
		public bool? allow180 { get; set; }  
		public double? g { get; set; }  
		public Handling? handling { get; set; }  

		public bool? no_szo { get; set; }  
		public int? garbagespeed { get; set; }  
		public int? garbagecap { get; set; }  
		public KicksetType? kickset { get; set; }  
		public int? boardwidth { get; set; }  
		public int? boardheight { get; set; }  
		public int? boardbuffer { get; set; }  
		public bool? physical { get; set; }  
		public bool? display_username { get; set; }  
		public string? username { get; set; }  
		public int? nextcount { get; set; }  
		public int? stock { get; set; }  
		public bool? hasgarbage { get; set; }  
		public bool? display_next { get; set; }  
		public bool? display_hold { get; set; }  
		public int? gmargin { get; set; }  
		public int? garbagemargin { get; set; }  
		public double? gincrease { get; set; }  
		public double? garbagecapincrease { get; set; }  
		public int? garbagecapmax { get; set; }  
		public double? garbageincrease { get; set; }  
		public BagType? bagtype { get; set; }  
		public SpinBonusesType? spinbonuses { get; set; }  
		public bool? allow_harddrop { get; set; }  
		public bool? display_shadow { get; set; }  
		public int? locktime { get; set; }  
		public int? are { get; set; }  
		public int? lineclear_are { get; set; }  
		public bool? infinitemovement { get; set; }  
		public bool? infinitehold { get; set; }  
		public int? lockresets { get; set; }  
		public bool? btbchaining { get; set; }  
		public bool? clutch { get; set; }  
		public PassthroughType? passthrough { get; set; }  
		public bool? nolockout { get; set; }  
		public GarbageBlockingType? garbageblocking { get; set; }  
		public double? garbagemultiplier { get; set; }  
		public ComboTableType? combotable { get;  set; }  
		public GarbageTargetBonusType? garbagetargetbonus { get;  set; }  
		public bool? garbageattackcap { get;  set; }  
		public object garbagephase { get;  set; }  
		public bool? garbagequeue { get;  set; }  
		public int? garbageholesize { get;  set; }  
		public bool? allclears { get;  set; }  
		public GarbageEntryType? garbageentry { get;  set; }
		public int? garbageare { get;  set; }
		public bool? shielded { get;  set; } 
		public bool? levels { get;  set; } 
		public double? levelspeed { get;  set; } 
		public double? gbase { get;  set; } 
		public double? gspeed { get;  set; } 
		public bool? masterlevels { get;  set; } 
	}
}