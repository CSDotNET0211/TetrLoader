using TetrLoader.Enum;
using TetrLoader.JsonClass.Event;

namespace TetrLoader.Ige;

public class IgeAllowTargeting : IgeBase
{
	public string? type { get; set; }
	public bool value { get; set; }
	public int? frame { get; set; }
	//these value is not used
	public string? gameid;
	public GarbageData? data;
	
	//compativility for v15
	public string? sender_id;

	public override object Clone()
		=> new IgeAllowTargeting()
		{
			frame = frame, type = type, value = value
		};
}