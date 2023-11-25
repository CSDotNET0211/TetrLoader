using System.Runtime.CompilerServices;
using TetrLoader.Enum;
using TetrLoader.JsonClass.Event;

namespace TetrLoader.Ige;

public class IgeAttack : IgeBase
{
	public string? type { get; set; }
	public int lines { get; set; }
	public int column { get; set; }
	public string? sender { get; set; }
	public int? sent_frame { get; set; }
	
	public int? cid { get; set; }

	public override object Clone()
		=> new IgeAttack()
		{
			type = type,
			lines = lines,
			column = column,
			sender = sender,
			sent_frame = sent_frame,
		};
}