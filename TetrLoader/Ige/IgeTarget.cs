using TetrLoader.Enum;
using TetrLoader.JsonClass.Event;

namespace TetrLoader.Ige;

public class IgeTarget : IgeBase
{
	public string? type { get; set; }
	public string[]? targets { get; set; }
	public int? frame { get; set; }
	
	public string? gameid{ get; set; }
	//this value is never used 
	public GarbageData? data;
	//compatibility for v15 targets event
	public string? sender_id{ get; set; }

	public override object Clone()
		=> new IgeTarget()
		{
			targets = targets,
			type = type,
			frame = frame,
		};
}